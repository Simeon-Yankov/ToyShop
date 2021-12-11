using Microsoft.EntityFrameworkCore.Migrations;

namespace ToyShop.Data.Migrations
{
    public partial class imageUrlColumnInToyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrls_Toys_ToyId",
                table: "ImageUrls");

            migrationBuilder.AlterColumn<int>(
                name: "ToyId",
                table: "ImageUrls",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrls_Toys_ToyId",
                table: "ImageUrls",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrls_Toys_ToyId",
                table: "ImageUrls");

            migrationBuilder.AlterColumn<int>(
                name: "ToyId",
                table: "ImageUrls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrls_Toys_ToyId",
                table: "ImageUrls",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
