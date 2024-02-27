using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addqtycart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "TbPurchasingCart",
                type: "int",
                nullable: true);

            

           

           

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "TbPurchasingCart");

            

           

          

           
           
        }
    }
}
