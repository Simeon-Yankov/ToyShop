using Microsoft.EntityFrameworkCore.Migrations;

namespace ToyShop.Data.Migrations
{
    public partial class updateImageUrlName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageUrls_Toys_ToyId",
                table: "ImageUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageUrls",
                table: "ImageUrls");

            migrationBuilder.RenameTable(
                name: "ImageUrls",
                newName: "ImagesUrls");

            migrationBuilder.RenameIndex(
                name: "IX_ImageUrls_ToyId",
                table: "ImagesUrls",
                newName: "IX_ImagesUrls_ToyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImagesUrls",
                table: "ImagesUrls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImagesUrls_Toys_ToyId",
                table: "ImagesUrls",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImagesUrls_Toys_ToyId",
                table: "ImagesUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImagesUrls",
                table: "ImagesUrls");

            migrationBuilder.RenameTable(
                name: "ImagesUrls",
                newName: "ImageUrls");

            migrationBuilder.RenameIndex(
                name: "IX_ImagesUrls_ToyId",
                table: "ImageUrls",
                newName: "IX_ImageUrls_ToyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageUrls",
                table: "ImageUrls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageUrls_Toys_ToyId",
                table: "ImageUrls",
                column: "ToyId",
                principalTable: "Toys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
