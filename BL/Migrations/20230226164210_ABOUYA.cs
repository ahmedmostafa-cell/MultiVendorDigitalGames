using Microsoft.EntityFrameworkCore.Migrations;

namespace BL.Migrations
{
    public partial class ABOUYA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThirdTtitleEn",
                table: "TbAboutUs",
                newName: "ThirdTtitleEn1");

            migrationBuilder.RenameColumn(
                name: "SecondTitleEn",
                table: "TbAboutUs",
                newName: "SecondTitleEn1");

            migrationBuilder.RenameColumn(
                name: "SecondTextEn",
                table: "TbAboutUs",
                newName: "SecondTextEn1");

            migrationBuilder.RenameColumn(
                name: "FirstTitleEn",
                table: "TbAboutUs",
                newName: "FirstTitleEn1");

            migrationBuilder.RenameColumn(
                name: "FirstTextEn",
                table: "TbAboutUs",
                newName: "FirstTextEn1");

            migrationBuilder.RenameColumn(
                name: "CreatedByEn",
                table: "TbAboutUs",
                newName: "CreatedByEn1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ThirdTtitleEn1",
                table: "TbAboutUs",
                newName: "ThirdTtitleEn");

            migrationBuilder.RenameColumn(
                name: "SecondTitleEn1",
                table: "TbAboutUs",
                newName: "SecondTitleEn");

            migrationBuilder.RenameColumn(
                name: "SecondTextEn1",
                table: "TbAboutUs",
                newName: "SecondTextEn");

            migrationBuilder.RenameColumn(
                name: "FirstTitleEn1",
                table: "TbAboutUs",
                newName: "FirstTitleEn");

            migrationBuilder.RenameColumn(
                name: "FirstTextEn1",
                table: "TbAboutUs",
                newName: "FirstTextEn");

            migrationBuilder.RenameColumn(
                name: "CreatedByEn1",
                table: "TbAboutUs",
                newName: "CreatedByEn");
        }
    }
}
