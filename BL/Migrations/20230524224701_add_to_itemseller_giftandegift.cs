using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_to_itemseller_giftandegift : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EGiftCard",
                table: "TbItemSubCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GiftCard",
                table: "TbItemSubCategory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BestSellingEGiftCard",
                table: "TbItemSeller",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BestSellingGiftCard",
                table: "TbItemSeller",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EGiftCard",
                table: "TbItemSubCategory");

            migrationBuilder.DropColumn(
                name: "GiftCard",
                table: "TbItemSubCategory");

            migrationBuilder.DropColumn(
                name: "BestSellingEGiftCard",
                table: "TbItemSeller");

            migrationBuilder.DropColumn(
                name: "BestSellingGiftCard",
                table: "TbItemSeller");
        }
    }
}
