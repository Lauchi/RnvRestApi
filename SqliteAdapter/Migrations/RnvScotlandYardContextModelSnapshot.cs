﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SqliteAdapter.Model;
using System;

namespace SqliteAdapter.Migrations
{
    [DbContext(typeof(RnvScotlandYardContext))]
    partial class RnvScotlandYardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("SqliteAdapter.Model.GameSessionDb", b =>
                {
                    b.Property<int>("GameSessionId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MrxId");

                    b.Property<string>("Name");

                    b.Property<DateTimeOffset>("StartTime");

                    b.HasKey("GameSessionId");

                    b.HasIndex("MrxId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("SqliteAdapter.Model.MovementsDb", b =>
                {
                    b.Property<int>("MovementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FromStationId");

                    b.Property<string>("ToStationId");

                    b.Property<int>("VehicleTypeId");

                    b.HasKey("MovementId");

                    b.HasIndex("VehicleTypeId");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("SqliteAdapter.Model.MrxDb", b =>
                {
                    b.Property<int>("MrxId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GameSessionDbId");

                    b.Property<string>("Name");

                    b.Property<int?>("TicketPoolDbTicketPoolId");

                    b.HasKey("MrxId");

                    b.HasIndex("TicketPoolDbTicketPoolId");

                    b.ToTable("MrXs");
                });

            modelBuilder.Entity("SqliteAdapter.Model.PoliceOfficerDb", b =>
                {
                    b.Property<int>("PoliceOfficerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GameSessionDbId");

                    b.Property<string>("Name");

                    b.Property<int>("TicketPoolDbId");

                    b.HasKey("PoliceOfficerId");

                    b.HasIndex("GameSessionDbId");

                    b.HasIndex("TicketPoolDbId");

                    b.ToTable("PoliceOfficers");
                });

            modelBuilder.Entity("SqliteAdapter.Model.TicketPoolDb", b =>
                {
                    b.Property<int>("TicketPoolId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlackTickets");

                    b.Property<int>("BusTickets");

                    b.Property<int>("DoubleTickets");

                    b.Property<int>("MetroTickets");

                    b.Property<int>("TaxiTickets");

                    b.HasKey("TicketPoolId");

                    b.ToTable("TicketPools");
                });

            modelBuilder.Entity("SqliteAdapter.Model.VehicleTypeDb", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VehicleType");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("SqliteAdapter.Model.GameSessionDb", b =>
                {
                    b.HasOne("SqliteAdapter.Model.MrxDb", "Mrx")
                        .WithMany()
                        .HasForeignKey("MrxId");
                });

            modelBuilder.Entity("SqliteAdapter.Model.MovementsDb", b =>
                {
                    b.HasOne("SqliteAdapter.Model.VehicleTypeDb", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SqliteAdapter.Model.MrxDb", b =>
                {
                    b.HasOne("SqliteAdapter.Model.TicketPoolDb", "TicketPoolDb")
                        .WithMany()
                        .HasForeignKey("TicketPoolDbTicketPoolId");
                });

            modelBuilder.Entity("SqliteAdapter.Model.PoliceOfficerDb", b =>
                {
                    b.HasOne("SqliteAdapter.Model.GameSessionDb", "GameSessionDb")
                        .WithMany("PoliceOfficers")
                        .HasForeignKey("GameSessionDbId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SqliteAdapter.Model.TicketPoolDb", "TicketPoolDb")
                        .WithMany()
                        .HasForeignKey("TicketPoolDbId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
