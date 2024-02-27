using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class addorderandorderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbOrderDetailss",
                columns: table => new
                {
                    OrderDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQty = table.Column<int>(type: "int", nullable: true),
                    SellerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSalePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PromocodeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocodeDiscountPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSalePriceAfterPromocode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    NumberOfAddFavourite = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOrderDetailss", x => x.OrderDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "TbOrders",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPriceBeforePromocode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PromocodeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocodeDiscountPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPriceAfterPromocode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentState = table.Column<int>(type: "int", nullable: true),
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOrders", x => x.OrderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbOrderDetailss");

            migrationBuilder.DropTable(
                name: "TbOrders");
        }
    }
}
