using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreDB.Migrations
{
    /// <inheritdoc />
    public partial class InitBooksAuthorsAndGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsSequel = table.Column<bool>(type: "bit", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    SequelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "Id", "FullName" },
                values: new object[,]
                {
                    { 1, "J.K. Rowling" },
                    { 2, "George R.R. Martin" },
                    { 3, "J.R.R. Tolkien" },
                    { 4, "Agatha Christie" },
                    { 5, "Dan Brown" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "AuthorId", "CostPrice", "GenreId", "IsSequel", "PageCount", "PublicationYear", "Publisher", "SellPrice", "SequelId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 10.00m, 1, true, 309, 1997, "Bloomsbury", 20.00m, 2, "Harry Potter and the Sorcerer's Stone" },
                    { 2, 2, 12.50m, 2, false, 694, 1996, "Bantam Spectra", 25.00m, null, "A Game of Thrones" },
                    { 3, 3, 8.00m, 3, true, 310, 1937, "HarperCollins", 16.00m, 4, "The Hobbit" },
                    { 4, 4, 5.00m, 4, false, 256, 1934, "Collins Crime Club", 10.00m, null, "Murder on the Orient Express" },
                    { 5, 5, 7.50m, 5, true, 454, 2003, "Doubleday", 15.00m, 6, "The Da Vinci Code" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Fantasy" },
                    { 2, "Epic Fantasy" },
                    { 3, "Adventure" },
                    { 4, "Mystery" },
                    { 5, "Thriller" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
