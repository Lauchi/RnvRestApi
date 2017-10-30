using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RnvTriasAdapter;
using RnvTriasAdapter.Mapper;
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
                .AddSingleton<IStationMapper, StationMapper>()
                .AddSingleton<IRnvRepository, RnvRepository>()
                .AddSingleton<IGameSessionRepository, GameSessionRepository>()
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}