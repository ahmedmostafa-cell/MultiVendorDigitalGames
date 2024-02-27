using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addcountryitemsellertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "TbItemSeller",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryNameEn",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "TbItemSeller");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "TbItemSeller");

            migrationBuilder.DropColumn(
                name: "CountryNameEn",
                table: "TbItemSeller");
        }
    }
}
