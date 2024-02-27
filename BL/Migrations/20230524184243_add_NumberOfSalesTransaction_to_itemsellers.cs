using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_NumberOfSalesTransaction_to_itemsellers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumberOfSalesTransaction",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfSalesTransaction",
                table: "TbItemSeller");
        }
    }
}
