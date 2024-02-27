using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class additemsellerimagetable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbItemSellerImagess",
                columns: table => new
                {
                    ItemSellerImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSalePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerItemEvaluationStarts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerItemEvaluationNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EvaluatersNumbers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Promoted = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteProfitMargin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: true),
                    NumberOfAddFavourite = table.Column<int>(type: "int", nullable: true),
                    NumberOfSalesTransaction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpComingGames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestSellingEGiftCard = table.Column<bool>(type: "bit", nullable: true),
                    BestSellingGiftCard = table.Column<bool>(type: "bit", nullable: true),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionNavigationRegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbItemSellerImagess", x => x.ItemSellerImageId);
                    table.ForeignKey(
                        name: "FK_TbItemSellerImagess_TbItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "TbItem",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbItemSellerImagess_TbRegion_RegionNavigationRegionId",
                        column: x => x.RegionNavigationRegionId,
                        principalTable: "TbRegion",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TbItemSellerImagess_TbSeller_SellerId",
                        column: x => x.SellerId,
                        principalTable: "TbSeller",
                        principalColumn: "SellerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbItemSellerImagess_ItemId",
                table: "TbItemSellerImagess",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TbItemSellerImagess_RegionNavigationRegionId",
                table: "TbItemSellerImagess",
                column: "RegionNavigationRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TbItemSellerImagess_SellerId",
                table: "TbItemSellerImagess",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbItemSellerImagess");
        }
    }
}
