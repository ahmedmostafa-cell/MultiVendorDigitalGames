using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_regionname_to_itemseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RegionName",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionName",
                table: "TbItemSeller");
        }
    }
}
