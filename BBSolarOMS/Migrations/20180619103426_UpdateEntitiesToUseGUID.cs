using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BBSolarOMS.Migrations
{
    public partial class UpdateEntitiesToUseGUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ActiveMail = table.Column<string>(nullable: false),
                    ActiveMobileNumber = table.Column<string>(nullable: false),
                    CoperateName = table.Column<string>(maxLength: 55, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    LGA = table.Column<string>(nullable: false),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    ResidentialProvinceAddress = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Installers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    MobileNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Installers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "Installers");
        }
    }
}
