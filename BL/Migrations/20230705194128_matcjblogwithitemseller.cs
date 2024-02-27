using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class matcjblogwithitemseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbBlog_TbBlogCategory",
                table: "TbBlog");

          

          

           

           

            migrationBuilder.AddColumn<string>(
                name: "BlogTitle",
                table: "TbBlogItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogTitleEn",
                table: "TbBlogItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemSellerId",
                table: "TbBlogItemSeller",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

         

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "BlogTitle",
                table: "TbBlogItemSeller");

            migrationBuilder.DropColumn(
                name: "BlogTitleEn",
                table: "TbBlogItemSeller");

            migrationBuilder.DropColumn(
                name: "ItemSellerId",
                table: "TbBlogItemSeller");

          

           

           

           

          
        }
    }
}
