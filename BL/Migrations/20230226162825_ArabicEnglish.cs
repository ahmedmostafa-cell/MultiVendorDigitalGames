using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class ArabicEnglish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.RenameColumn(
                name: "OperatingSystem",
                table: "TbItem",
                newName: "OperatingSystemId");

            migrationBuilder.AlterColumn<string>(
                name: "TypeTitle",
                table: "TbType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypeDescription",
                table: "TbType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypeDescriptionEn",
                table: "TbType",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeTitleEn",
                table: "TbType",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "TicketCategoryName",
                table: "TbTicketCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TicketText",
                table: "TbTicket",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TicketCategoryId",
                table: "TbTicket",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoryTitle",
                table: "TbSubCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoryDescription",
                table: "TbSubCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MainCategoryId",
                table: "TbSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryDescriptionEn",
                table: "TbSubCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryTitleEn",
                table: "TbSubCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "SliderTitle",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SliderOrderNo",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SliderImagePath",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SliderDescription",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderDescriptionEn",
                table: "TbSlider",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SliderTitleEn",
                table: "TbSlider",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "ValueAddedTax",
                table: "TbSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OffersValidityDays",
                table: "TbSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AppProfitPercent",
                table: "TbSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WebsiteProfitMargin",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubscribeFees",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "TbSellerSubscribe",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WbesiteProfitMargin",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TypesOfItems",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TaxIdentificationNo",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerPhoneNumber",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerFullName",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerEmail",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefrenceId",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "QtyAvailabeToSell",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoOfSKUs",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentF",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentE",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentD",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentC",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentB",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentA",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyType",
                table: "TbSeller",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessZipCode",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessWebsite",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessTradeName",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessCountry",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessCirtyId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessAddress",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerFullNamen",
                table: "TbSeller",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "TbRegion",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionNameEn",
                table: "TbRegion",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "TbPromotingItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromotioValue",
                table: "TbPromotingItemSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbPromotingItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromocodeTitle",
                table: "TbPromocode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromocodeDiscountPercent",
                table: "TbPromocode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PoliciesAndPrivacyTitle",
                table: "TbPolicyAndPrivacy",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PoliciesAndPrivacyDescription",
                table: "TbPolicyAndPrivacy",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoliciesAndPrivacyDescriptionEn",
                table: "TbPolicyAndPrivacy",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PoliciesAndPrivacyTitleEn",
                table: "TbPolicyAndPrivacy",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystemNameEn",
                table: "TbOperatingSystem",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "TbMainCategory",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainCategoryTitle",
                table: "TbMainCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MainCategoryDescription",
                table: "TbMainCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCategoryDescriptionEn",
                table: "TbMainCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainCategoryTitleEn",
                table: "TbMainCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubCategoryId",
                table: "TbItemSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbItemSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameEn",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionEn",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerNameEn",
                table: "TbItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TbItem",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameEn",
                table: "TbItem",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystemName",
                table: "TbItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperatingSystemNameEn",
                table: "TbItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionEn",
                table: "TbItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorksOnEn",
                table: "TbItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameEn",
                table: "TbFavouriteCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegionEn",
                table: "TbFavouriteCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerNameEn",
                table: "TbFavouriteCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameEn",
                table: "TbFavouriteCart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAQSubCategoryName",
                table: "TbFAQSubCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "FAQCategoryId",
                table: "TbFAQSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqcategoryNameEn",
                table: "TbFAQSubCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqsubCategoryNameEn",
                table: "TbFAQSubCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FAQCategoryName",
                table: "TbFAQCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqcategoryNameEn",
                table: "TbFAQCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "FAQSubCategoryId",
                table: "TbFAQ",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAQQuestion",
                table: "TbFAQ",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FAQAnswer",
                table: "TbFAQ",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FaqanswerEn",
                table: "TbFAQ",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FaqquestionEn",
                table: "TbFAQ",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FaqsubCategoryNameEn",
                table: "TbFAQ",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameEn",
                table: "TbEvaluationCommentLike",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameEn",
                table: "TbEvaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerNameEn",
                table: "TbEvaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNameEn",
                table: "TbEvaluation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyName",
                table: "TbCurrency",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyNameEn",
                table: "TbCurrency",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "TbCountry",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryNameEn",
                table: "TbCountry",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "RuleName",
                table: "TbCompetitionRule",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RuleNameEn",
                table: "TbCompetitionRule",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CompetitionTitle",
                table: "TbCompetition",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompetitionTitleEn",
                table: "TbCompetition",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "TbCity",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityNameEn",
                table: "TbCity",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogTopicNameEn",
                table: "TbBlogTopic",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbBlogItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameEn",
                table: "TbBlogItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerNameEn",
                table: "TbBlogItemSeller",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogImageTitle",
                table: "TbBlogImage",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BlogImageText",
                table: "TbBlogImage",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogImageTextEn",
                table: "TbBlogImage",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogImageTitleEn",
                table: "TbBlogImage",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActionPersonNameEn",
                table: "TbBlogCommentLike",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CommenterId",
                table: "TbBlogComment",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogCategoryNameEn",
                table: "TbBlogCategory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogCategoryNameEn",
                table: "TbBlog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BlogShortDescriptionEn",
                table: "TbBlog",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogTitleEn",
                table: "TbBlog",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BlogTopicNameEn",
                table: "TbBlog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemNameEn",
                table: "TbBlog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerNameEn",
                table: "TbBlog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstTextEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstTitleEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondTextEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondTitleEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdTtitleEn",
                table: "TbAboutUs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "TypeDescriptionEn",
                table: "TbType");

            migrationBuilder.DropColumn(
                name: "TypeTitleEn",
                table: "TbType");

            migrationBuilder.DropColumn(
                name: "SubCategoryDescriptionEn",
                table: "TbSubCategory");

            migrationBuilder.DropColumn(
                name: "SubCategoryTitleEn",
                table: "TbSubCategory");

            migrationBuilder.DropColumn(
                name: "SliderDescriptionEn",
                table: "TbSlider");

            migrationBuilder.DropColumn(
                name: "SliderTitleEn",
                table: "TbSlider");

            migrationBuilder.DropColumn(
                name: "SellerFullNamen",
                table: "TbSeller");

            migrationBuilder.DropColumn(
                name: "RegionNameEn",
                table: "TbRegion");

            migrationBuilder.DropColumn(
                name: "PoliciesAndPrivacyDescriptionEn",
                table: "TbPolicyAndPrivacy");

            migrationBuilder.DropColumn(
                name: "PoliciesAndPrivacyTitleEn",
                table: "TbPolicyAndPrivacy");

            migrationBuilder.DropColumn(
                name: "OperatingSystemNameEn",
                table: "TbOperatingSystem");

            migrationBuilder.DropColumn(
                name: "MainCategoryDescriptionEn",
                table: "TbMainCategory");

            migrationBuilder.DropColumn(
                name: "MainCategoryTitleEn",
                table: "TbMainCategory");

            migrationBuilder.DropColumn(
                name: "ItemNameEn",
                table: "TbItemSeller");

            migrationBuilder.DropColumn(
                name: "RegionEn",
                table: "TbItemSeller");

            migrationBuilder.DropColumn(
                name: "SellerNameEn",
                table: "TbItemSeller");

            migrationBuilder.DropColumn(
                name: "ItemNameEn",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "OperatingSystemName",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "OperatingSystemNameEn",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "RegionEn",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "WorksOnEn",
                table: "TbItem");

            migrationBuilder.DropColumn(
                name: "ItemNameEn",
                table: "TbFavouriteCart");

            migrationBuilder.DropColumn(
                name: "RegionEn",
                table: "TbFavouriteCart");

            migrationBuilder.DropColumn(
                name: "SellerNameEn",
                table: "TbFavouriteCart");

            migrationBuilder.DropColumn(
                name: "UserNameEn",
                table: "TbFavouriteCart");

            migrationBuilder.DropColumn(
                name: "FaqcategoryNameEn",
                table: "TbFAQSubCategory");

            migrationBuilder.DropColumn(
                name: "FaqsubCategoryNameEn",
                table: "TbFAQSubCategory");

            migrationBuilder.DropColumn(
                name: "FaqcategoryNameEn",
                table: "TbFAQCategory");

            migrationBuilder.DropColumn(
                name: "FaqanswerEn",
                table: "TbFAQ");

            migrationBuilder.DropColumn(
                name: "FaqquestionEn",
                table: "TbFAQ");

            migrationBuilder.DropColumn(
                name: "FaqsubCategoryNameEn",
                table: "TbFAQ");

            migrationBuilder.DropColumn(
                name: "UserNameEn",
                table: "TbEvaluationCommentLike");

            migrationBuilder.DropColumn(
                name: "ItemNameEn",
                table: "TbEvaluation");

            migrationBuilder.DropColumn(
                name: "SellerNameEn",
                table: "TbEvaluation");

            migrationBuilder.DropColumn(
                name: "UserNameEn",
                table: "TbEvaluation");

            migrationBuilder.DropColumn(
                name: "CurrencyNameEn",
                table: "TbCurrency");

            migrationBuilder.DropColumn(
                name: "CountryNameEn",
                table: "TbCountry");

            migrationBuilder.DropColumn(
                name: "RuleNameEn",
                table: "TbCompetitionRule");

            migrationBuilder.DropColumn(
                name: "CompetitionTitleEn",
                table: "TbCompetition");

            migrationBuilder.DropColumn(
                name: "CityNameEn",
                table: "TbCity");

            migrationBuilder.DropColumn(
                name: "BlogTopicNameEn",
                table: "TbBlogTopic");

            migrationBuilder.DropColumn(
                name: "ItemNameEn",
                table: "TbBlogItemSeller");

            migrationBuilder.DropColumn(
                name: "SellerNameEn",
                table: "TbBlogItemSeller");

            migrationBuilder.DropColumn(
                name: "BlogImageTextEn",
                table: "TbBlogImage");

            migrationBuilder.DropColumn(
                name: "BlogImageTitleEn",
                table: "TbBlogImage");

            migrationBuilder.DropColumn(
                name: "ActionPersonNameEn",
                table: "TbBlogCommentLike");

            migrationBuilder.DropColumn(
                name: "BlogCategoryNameEn",
                table: "TbBlogCategory");

            migrationBuilder.DropColumn(
                name: "BlogCategoryNameEn",
                table: "TbBlog");

            migrationBuilder.DropColumn(
                name: "BlogShortDescriptionEn",
                table: "TbBlog");

            migrationBuilder.DropColumn(
                name: "BlogTitleEn",
                table: "TbBlog");

            migrationBuilder.DropColumn(
                name: "BlogTopicNameEn",
                table: "TbBlog");

            migrationBuilder.DropColumn(
                name: "ItemNameEn",
                table: "TbBlog");

            migrationBuilder.DropColumn(
                name: "SellerNameEn",
                table: "TbBlog");

            migrationBuilder.DropColumn(
                name: "CreatedByEn",
                table: "TbAboutUs");

            migrationBuilder.DropColumn(
                name: "FirstTextEn",
                table: "TbAboutUs");

            migrationBuilder.DropColumn(
                name: "FirstTitleEn",
                table: "TbAboutUs");

            migrationBuilder.DropColumn(
                name: "SecondTextEn",
                table: "TbAboutUs");

            migrationBuilder.DropColumn(
                name: "SecondTitleEn",
                table: "TbAboutUs");

            migrationBuilder.DropColumn(
                name: "ThirdTtitleEn",
                table: "TbAboutUs");

            migrationBuilder.RenameColumn(
                name: "OperatingSystemId",
                table: "TbItem",
                newName: "OperatingSystem");

            migrationBuilder.AlterColumn<string>(
                name: "TypeTitle",
                table: "TbType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TypeDescription",
                table: "TbType",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TicketCategoryName",
                table: "TbTicketCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TicketText",
                table: "TbTicket",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "TicketCategoryId",
                table: "TbTicket",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoryTitle",
                table: "TbSubCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoryDescription",
                table: "TbSubCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "MainCategoryId",
                table: "TbSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "SliderTitle",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SliderOrderNo",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SliderImagePath",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SliderDescription",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "TbSlider",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ValueAddedTax",
                table: "TbSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "OffersValidityDays",
                table: "TbSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "AppProfitPercent",
                table: "TbSetting",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "WebsiteProfitMargin",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SubscribeFees",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "StartDate",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "TbSellerSubscribe",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "TbSellerSubscribe",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "WbesiteProfitMargin",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "VatNumber",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TypesOfItems",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "TaxIdentificationNo",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SellerPhoneNumber",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SellerFullName",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "SellerEmail",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "RefrenceId",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "QtyAvailabeToSell",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NoOfSKUs",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentF",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentE",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentD",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentC",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentB",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DocumentA",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CompanyType",
                table: "TbSeller",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyName",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessZipCode",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessWebsite",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessTradeName",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessCountry",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "BusinessCirtyId",
                table: "TbSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BusinessAddress",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "TbSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "TbRegion",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "SellerId",
                table: "TbPromotingItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PromotioValue",
                table: "TbPromotingItemSeller",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbPromotingItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "PromocodeTitle",
                table: "TbPromocode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PromocodeDiscountPercent",
                table: "TbPromocode",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PoliciesAndPrivacyTitle",
                table: "TbPolicyAndPrivacy",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "PoliciesAndPrivacyDescription",
                table: "TbPolicyAndPrivacy",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "TypeId",
                table: "TbMainCategory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "MainCategoryTitle",
                table: "TbMainCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MainCategoryDescription",
                table: "TbMainCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "SubCategoryId",
                table: "TbItemSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbItemSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TbItem",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FAQSubCategoryName",
                table: "TbFAQSubCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "FAQCategoryId",
                table: "TbFAQSubCategory",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FAQCategoryName",
                table: "TbFAQCategory",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "FAQSubCategoryId",
                table: "TbFAQ",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "FAQQuestion",
                table: "TbFAQ",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FAQAnswer",
                table: "TbFAQ",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CurrencyName",
                table: "TbCurrency",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CountryName",
                table: "TbCountry",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "RuleName",
                table: "TbCompetitionRule",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CompetitionTitle",
                table: "TbCompetition",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CityName",
                table: "TbCity",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "TbBlogItemSeller",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "BlogImageTitle",
                table: "TbBlogImage",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BlogImageText",
                table: "TbBlogImage",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CommenterId",
                table: "TbBlogComment",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

          
        }
    }
}
