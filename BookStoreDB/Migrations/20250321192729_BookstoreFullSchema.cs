using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreDB.Migrations
{
    /// <inheritdoc />
    public partial class BookstoreFullSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "accounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "accounts",
                newName: "Login");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "accounts",
                newName: "Id");

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(2,0)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(2,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPromotion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPromotion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookPromotion_Promotion_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPromotion_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_AuthorId",
                table: "books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_books_GenreId",
                table: "books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPromotion_BookId",
                table: "BookPromotion",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPromotion_PromotionId",
                table: "BookPromotion",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_BookId",
                table: "Discounts",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_authors_AuthorId",
                table: "books",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_authors_AuthorId",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_genres_GenreId",
                table: "books");

            migrationBuilder.DropTable(
                name: "BookPromotion");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Promotion");

            migrationBuilder.DropIndex(
                name: "IX_books_AuthorId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_GenreId",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "accounts",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Login",
                table: "accounts",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "accounts",
                newName: "id");
        }
    }
}
