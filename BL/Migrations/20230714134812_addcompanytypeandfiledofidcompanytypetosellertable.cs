using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addcompanytypeandfiledofidcompanytypetosellertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyTypeId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true);

          

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyTypeId",
                table: "TbSeller");

            
        }
    }
}
