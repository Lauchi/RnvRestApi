using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SqliteAdapter.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketPools",
                columns: table => new
                {
                    TicketPoolId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BlackTickets = table.Column<int>(type: "INTEGER", nullable: false),
                    BusTickets = table.Column<int>(type: "INTEGER", nullable: false),
                    DoubleTickets = table.Column<int>(type: "INTEGER", nullable: false),
                    MetroTickets = table.Column<int>(type: "INTEGER", nullable: false),
                    TaxiTickets = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPools", x => x.TicketPoolId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "MrXs",
                columns: table => new
                {
                    MrxId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameSessionDbId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TicketPoolDbTicketPoolId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrXs", x => x.MrxId);
                    table.ForeignKey(
                        name: "FK_MrXs_TicketPools_TicketPoolDbTicketPoolId",
                        column: x => x.TicketPoolDbTicketPoolId,
                        principalTable: "TicketPools",
                        principalColumn: "TicketPoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    MovementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FromStationId = table.Column<string>(type: "TEXT", nullable: true),
                    ToStationId = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.MovementId);
                    table.ForeignKey(
                        name: "FK_Movements_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    GameSessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MrxId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.GameSessionId);
                    table.ForeignKey(
                        name: "FK_GameSessions_MrXs_MrxId",
                        column: x => x.MrxId,
                        principalTable: "MrXs",
                        principalColumn: "MrxId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoliceOfficers",
                columns: table => new
                {
                    PoliceOfficerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameSessionDbGameSessionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TicketPoolDbTicketPoolId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceOfficers", x => x.PoliceOfficerId);
                    table.ForeignKey(
                        name: "FK_PoliceOfficers_GameSessions_GameSessionDbGameSessionId",
                        column: x => x.GameSessionDbGameSessionId,
                        principalTable: "GameSessions",
                        principalColumn: "GameSessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoliceOfficers_TicketPools_TicketPoolDbTicketPoolId",
                        column: x => x.TicketPoolDbTicketPoolId,
                        principalTable: "TicketPools",
                        principalColumn: "TicketPoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameSessions_MrxId",
                table: "GameSessions",
                column: "MrxId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_VehicleTypeId",
                table: "Movements",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MrXs_TicketPoolDbTicketPoolId",
                table: "MrXs",
                column: "TicketPoolDbTicketPoolId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_GameSessionDbGameSessionId",
                table: "PoliceOfficers",
                column: "GameSessionDbGameSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_TicketPoolDbTicketPoolId",
                table: "PoliceOfficers",
                column: "TicketPoolDbTicketPoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "PoliceOfficers");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropTable(
                name: "GameSessions");

            migrationBuilder.DropTable(
                name: "MrXs");

            migrationBuilder.DropTable(
                name: "TicketPools");
        }
    }
}
