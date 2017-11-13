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
                name: "MrXs",
                columns: table => new
                {
                    MrxId = table.Column<string>(type: "TEXT", nullable: false),
                    GameSessionDbId = table.Column<string>(type: "TEXT", nullable: true),
                    LastKnownStation = table.Column<string>(type: "TEXT", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "PoliceOfficers",
                columns: table => new
                {
                    PoliceOfficerId = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentStationId = table.Column<string>(type: "TEXT", nullable: true),
                    GameSessionDbId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliceOfficers", x => x.PoliceOfficerId);
                    table.ForeignKey(
                        name: "FK_PoliceOfficers_GameSessions_GameSessionDbId",
                        column: x => x.GameSessionDbId,
                        principalTable: "GameSessions",
                        principalColumn: "GameSessionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoveMrX",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MrxDbMrxId = table.Column<string>(type: "TEXT", nullable: true),
                    StationId = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoveMrX", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_MoveMrX_MrXs_MrxDbMrxId",
                        column: x => x.MrxDbMrxId,
                        principalTable: "MrXs",
                        principalColumn: "MrxId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenMoveMrx",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MrxDbMrxId = table.Column<string>(type: "TEXT", nullable: true),
                    StationId = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenMoveMrx", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_OpenMoveMrx_MrXs_MrxDbMrxId",
                        column: x => x.MrxDbMrxId,
                        principalTable: "MrXs",
                        principalColumn: "MrxId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovePoliceOfficers",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PoliceOfficerDbPoliceOfficerId = table.Column<string>(type: "TEXT", nullable: true),
                    StationId = table.Column<string>(type: "TEXT", nullable: true),
                    VehicleType = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovePoliceOfficers", x => x.MoveId);
                    table.ForeignKey(
                        name: "FK_MovePoliceOfficers_PoliceOfficers_PoliceOfficerDbPoliceOfficerId",
                        column: x => x.PoliceOfficerDbPoliceOfficerId,
                        principalTable: "PoliceOfficers",
                        principalColumn: "PoliceOfficerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoveMrX_MrxDbMrxId",
                table: "MoveMrX",
                column: "MrxDbMrxId");

            migrationBuilder.CreateIndex(
                name: "IX_MovePoliceOfficers_PoliceOfficerDbPoliceOfficerId",
                table: "MovePoliceOfficers",
                column: "PoliceOfficerDbPoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_MrXs_GameSessionDbId",
                table: "MrXs",
                column: "GameSessionDbId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenMoveMrx_MrxDbMrxId",
                table: "OpenMoveMrx",
                column: "MrxDbMrxId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_GameSessionDbId",
                table: "PoliceOfficers",
                column: "GameSessionDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoveMrX");

            migrationBuilder.DropTable(
                name: "MovePoliceOfficers");

            migrationBuilder.DropTable(
                name: "OpenMoveMrx");

            migrationBuilder.DropTable(
                name: "PoliceOfficers");

            migrationBuilder.DropTable(
                name: "MrXs");

            migrationBuilder.DropTable(
                name: "GameSessions");
        }
    }
}
