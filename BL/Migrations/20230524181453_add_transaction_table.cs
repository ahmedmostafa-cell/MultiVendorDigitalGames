using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class add_transaction_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemSellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SellerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerNameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemSalePrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PromocodeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PromocodeDiscountPercent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    temSalePriceAfterPromocode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    TransactionStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTransactions", x => x.TransactionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbTransactions");
        }
    }
}
