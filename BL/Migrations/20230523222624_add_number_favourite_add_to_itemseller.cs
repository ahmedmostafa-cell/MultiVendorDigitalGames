using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_number_favourite_add_to_itemseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfAddFavourite",
                table: "TbItemSeller",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfAddFavourite",
                table: "TbItemSeller");
        }
    }
}
