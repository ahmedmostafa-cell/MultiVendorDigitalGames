using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class adddescroptionitembloggerseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDescroption",
                table: "TbBlogItemSeller",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortDescroptionEn",
                table: "TbBlogItemSeller",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDescroption",
                table: "TbBlogItemSeller");

            migrationBuilder.DropColumn(
                name: "ShortDescroptionEn",
                table: "TbBlogItemSeller");
        }
    }
}
