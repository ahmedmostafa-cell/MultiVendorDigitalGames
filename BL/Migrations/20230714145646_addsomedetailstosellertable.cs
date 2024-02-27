using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addsomedetailstosellertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyNumber",
                table: "TbSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyTypeEn",
                table: "TbSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "TbSeller",
                type: "nvarchar(max)",
                nullable: true);

           

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyNumber",
                table: "TbSeller");

            migrationBuilder.DropColumn(
                name: "CompanyTypeEn",
                table: "TbSeller");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "TbSeller");

          

           
        }
    }
}
