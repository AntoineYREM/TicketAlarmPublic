using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketAlarm.Persistence.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alarms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShow = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTimeMailRequest = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeMailSent = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeTextRequest = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeTextSent = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Availabilitys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdShow = table.Column<int>(type: "int", nullable: false),
                    DateTimeAvailability = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilitys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTimeShow = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdFnac = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    IdArtist = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shows_Artists_IdArtist",
                        column: x => x.IdArtist,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alarms",
                columns: new[] { "Id", "DateTimeMailRequest", "DateTimeMailSent", "DateTimeTextRequest", "DateTimeTextSent", "IdShow", "Mail", "Phone" },
                values: new object[] { 1, null, null, null, null, 1, "test@gmail.com", "+33622334455" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name", "UrlPhoto" },
                values: new object[] { 1, "Billie Eilish", "https://www.fnacspectacles.com/obj/mam/france/9c/4a/billi-eilish-tickets_152737_1374605_222x222.jpg" });

            migrationBuilder.InsertData(
                table: "Availabilitys",
                columns: new[] { "Id", "DateTimeAvailability", "IdShow" },
                values: new object[] { 1, new DateTime(2024, 10, 3, 17, 40, 49, 656, DateTimeKind.Local).AddTicks(5928), 1 });

            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "Id", "Arena", "Available", "City", "DateTimeShow", "IdArtist", "IdFnac", "Title", "Url" },
                values: new object[] { 1, "Accor Arena", false, "Paris", new DateTime(2025, 6, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, 18631108, "Billie Eilish - Hit Me Hard and Soft Tour", "https://www.fnacspectacles.com/event/billie-eilish-hit-me-hard-and-soft-tour-accor-arena-18631108/" });

            migrationBuilder.CreateIndex(
                name: "IX_Shows_IdArtist",
                table: "Shows",
                column: "IdArtist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alarms");

            migrationBuilder.DropTable(
                name: "Availabilitys");

            migrationBuilder.DropTable(
                name: "Shows");

            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
