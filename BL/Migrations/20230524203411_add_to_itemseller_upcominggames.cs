using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_to_itemseller_upcominggames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UpComingGames",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpComingGames",
                table: "TbItemSeller");
        }
    }
}
