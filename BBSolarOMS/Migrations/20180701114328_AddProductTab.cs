using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BBSolarOMS.Migrations
{
    public partial class AddProductTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    LastStalkDate = table.Column<DateTimeOffset>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    ProductPicture = table.Column<byte>(nullable: false),
                    stockQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
