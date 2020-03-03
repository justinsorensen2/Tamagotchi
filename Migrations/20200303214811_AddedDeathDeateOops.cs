using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tamagotchi.Migrations
{
    public partial class AddedDeathDeateOops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeathDate",
                table: "Pets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDead",
                table: "Pets",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastInteractedWith",
                table: "Pets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeathDate",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "IsDead",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "LastInteractedWith",
                table: "Pets");
        }
    }
}
