using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketAlarm.Persistence.Migrations
{
    public partial class Ajoutuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Screenshot",
                table: "Availabilitys",
                type: "varchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Availabilitys",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeAvailability",
                value: new DateTime(2024, 10, 10, 20, 26, 38, 534, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "EmailAddress", "Password", "Role" },
                values: new object[] { 1, "test@ticketalarm.com", "yourStrong(!)Password", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Screenshot",
                table: "Availabilitys",
                type: "varchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Availabilitys",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTimeAvailability",
                value: new DateTime(2024, 10, 5, 14, 58, 30, 105, DateTimeKind.Local).AddTicks(6058));
        }
    }
}
