using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SqliteAdapter.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameSessions",
                columns: table => new
                {
                    GameSessionId = table.Column<string>(type: "TEXT", nullable: false),
                    MaxPoliceOfficers = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StartTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameSessions", x => x.GameSessionId);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    StationId = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.StationId);
                });

            migrationBuilder.CreateTable(
                name: "MrXs",
                columns: table => new
                {
                    MrxId = table.Column<string>(type: "TEXT", nullable: false),
                    GameSessionDbId = table.Column<string>(type: "TEXT", nullable: true),
                    LastKnownStationStationId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MrXs", x => x.MrxId);
                    table.ForeignKey(
                        name: "FK_MrXs_GameSessions_GameSessionDbId",
                        column: x => x.GameSessionDbId,
                        principalTable: "GameSessions",
                        principalColumn: "GameSessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MrXs_Stations_LastKnownStationStationId",
                        column: x => x.LastKnownStationStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PoliceOfficers",
                columns: table => new
                {
                    PoliceOfficerId = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentStationStationId = table.Column<string>(type: "TEXT", nullable: true),
                    GameSessionDbId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceOfficers", x => x.PoliceOfficerId);
                    table.ForeignKey(
                        name: "FK_PoliceOfficers_Stations_CurrentStationStationId",
                        column: x => x.CurrentStationStationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PoliceOfficers_GameSessions_GameSessionDbId",
                        column: x => x.GameSessionDbId,
                        principalTable: "GameSessions",
                        principalColumn: "GameSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MrxDbMrxId = table.Column<string>(type: "TEXT", nullable: true),
                    MrxDbMrxId1 = table.Column<string>(type: "TEXT", nullable: true),
                    PoliceOfficerDbPoliceOfficerId = table.Column<string>(type: "TEXT", nullable: true),
                    StationId = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_Moves_MrXs_MrxDbMrxId",
                        column: x => x.MrxDbMrxId,
                        principalTable: "MrXs",
                        principalColumn: "MrxId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_MrXs_MrxDbMrxId1",
                        column: x => x.MrxDbMrxId1,
                        principalTable: "MrXs",
                        principalColumn: "MrxId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_PoliceOfficers_PoliceOfficerDbPoliceOfficerId",
                        column: x => x.PoliceOfficerDbPoliceOfficerId,
                        principalTable: "PoliceOfficers",
                        principalColumn: "PoliceOfficerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MrxDbMrxId",
                table: "Moves",
                column: "MrxDbMrxId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_MrxDbMrxId1",
                table: "Moves",
                column: "MrxDbMrxId1");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PoliceOfficerDbPoliceOfficerId",
                table: "Moves",
                column: "PoliceOfficerDbPoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_StationId",
                table: "Moves",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_MrXs_GameSessionDbId",
                table: "MrXs",
                column: "GameSessionDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MrXs_LastKnownStationStationId",
                table: "MrXs",
                column: "LastKnownStationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_CurrentStationStationId",
                table: "PoliceOfficers",
                column: "CurrentStationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_GameSessionDbId",
                table: "PoliceOfficers",
                column: "GameSessionDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "MrXs");

            migrationBuilder.DropTable(
                name: "PoliceOfficers");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DropTable(
                name: "GameSessions");
        }
    }
}
