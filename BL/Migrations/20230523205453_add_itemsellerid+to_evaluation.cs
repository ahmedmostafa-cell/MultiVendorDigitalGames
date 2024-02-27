using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_itemselleridto_evaluation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<Guid>(
                name: "ItemSellerId",
                table: "TbEvaluation",
                type: "uniqueidentifier",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "ItemSellerId",
                table: "TbEvaluation");

            
        }
    }
}
