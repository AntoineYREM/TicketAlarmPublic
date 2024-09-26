using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketAlarm.Persistence.Migrations
{
    public partial class cléétrangère : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availabilitys",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeAvailability",
                value: new DateTime(2024, 9, 26, 13, 24, 43, 354, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.CreateIndex(
                name: "IX_Shows_IdArtist",
                table: "Shows",
                column: "IdArtist");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Artists_IdArtist",
                table: "Shows",
                column: "IdArtist",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Artists_IdArtist",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_IdArtist",
                table: "Shows");

            migrationBuilder.UpdateData(
                table: "Availabilitys",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeAvailability",
                value: new DateTime(2024, 9, 20, 22, 16, 21, 870, DateTimeKind.Local).AddTicks(8892));
        }
    }
}
