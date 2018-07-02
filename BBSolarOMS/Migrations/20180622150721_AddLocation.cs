using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BBSolarOMS.Migrations
{
    public partial class AddLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LGA",
                table: "Installers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Installers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LGA",
                table: "Installers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Installers");
        }
    }
}
