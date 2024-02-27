using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class ABOUYAa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpdatedByEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedByEn",
                table: "TbAboutUs");
        }
    }
}
