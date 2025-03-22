using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreDB.Migrations
{
    /// <inheritdoc />
    public partial class PromotionsAndDiscounts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPromotion_Promotion_PromotionId",
                table: "BookPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_books_BookId",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion");

            migrationBuilder.RenameTable(
                name: "Discounts",
                newName: "discounts");

            migrationBuilder.RenameTable(
                name: "Promotion",
                newName: "promotions");

            migrationBuilder.RenameIndex(
                name: "IX_Discounts_BookId",
                table: "discounts",
                newName: "IX_discounts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_discounts",
                table: "discounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_promotions",
                table: "promotions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPromotion_promotions_PromotionId",
                table: "BookPromotion",
                column: "PromotionId",
                principalTable: "promotions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_discounts_books_BookId",
                table: "discounts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPromotion_promotions_PromotionId",
                table: "BookPromotion");

            migrationBuilder.DropForeignKey(
                name: "FK_discounts_books_BookId",
                table: "discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_discounts",
                table: "discounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_promotions",
                table: "promotions");

            migrationBuilder.RenameTable(
                name: "discounts",
                newName: "Discounts");

            migrationBuilder.RenameTable(
                name: "promotions",
                newName: "Promotion");

            migrationBuilder.RenameIndex(
                name: "IX_discounts_BookId",
                table: "Discounts",
                newName: "IX_Discounts_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discounts",
                table: "Discounts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotion",
                table: "Promotion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookPromotion_Promotion_PromotionId",
                table: "BookPromotion",
                column: "PromotionId",
                principalTable: "Promotion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_books_BookId",
                table: "Discounts",
                column: "BookId",
                principalTable: "books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
