using System;
using System.Net.Http;
using System.Security.Claims;
using EventStoring;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestAdapter.Controllers;
using RnvTriasAdapter;
using RnvTriasAdapter.Mapper;
using SqliteAdapter.Model;
using SqliteAdapter.Repositories;

namespace RnvRestApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://trias.vrn.de/Middleware/Data/trias");
            var rnvClient = new RnvClient(httpClient);

            services.AddSingleton(rnvClient)
                .AddDbContext<RnvScotlandYardContext>(option => option.UseSqlite("Data Source=rnvScotlandYard.db"))
                .AddSingleton<IStationMapper, StationMapper>()
                .AddSingleton<IDbMapping, DbMapping>()
                .AddSingleton<IRnvRepository, RnvRepository>()
                .AddSingleton<IGameSessionRepository, GameSessionRepository>()
                .AddSingleton<IMrxRepository, MrxRepository>()
                .AddSingleton<IPoliceOfficerRepository, PoliceOfficerRepository>()
                .AddSingleton<IStartupLoadRepository, StartupLoadRepository>()
                .AddSingleton<IEventStore, EventStore>()
                .AddAuthorization()
                .AddMvc(config =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .AddRequirements(new ApiKeyRequirement())
                        .Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var serviceScope = serviceScopeFactory.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<RnvScotlandYardContext>();
                dbContext.Database.EnsureCreated();

                var loader = serviceScope.ServiceProvider.GetService<IStartupLoadRepository>();
                loader.LoadSessions().Wait();
            }
            app.UseMvc();
        }
    }
}