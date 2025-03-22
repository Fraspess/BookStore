﻿// <auto-generated />
using System;
using BookStoreDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreDB.Migrations
{
    [DbContext(typeof(BookStore))]
    [Migration("20250322182008_IsAdminRevert")]
    partial class IsAdminRevert
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreDB.Entities.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Login = "admin",
                            Password = "admin"
                        },
                        new
                        {
                            Id = -2,
                            Login = "user",
                            Password = "user"
                        });
                });

            modelBuilder.Entity("BookStoreDB.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "J.K. Rowling"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "George R.R. Martin"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "J.R.R. Tolkien"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "Agatha Christie"
                        },
                        new
                        {
                            Id = 5,
                            FullName = "Dan Brown"
                        });
                });

            modelBuilder.Entity("BookStoreDB.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSequel")
                        .HasColumnType("bit");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SequelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CostPrice = 10.00m,
                            GenreId = 1,
                            IsSequel = true,
                            PageCount = 309,
                            PublicationYear = 1997,
                            Publisher = "Bloomsbury",
                            SellPrice = 20.00m,
                            SequelId = 2,
                            Title = "Harry Potter and the Sorcerer's Stone"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            CostPrice = 12.50m,
                            GenreId = 2,
                            IsSequel = false,
                            PageCount = 694,
                            PublicationYear = 1996,
                            Publisher = "Bantam Spectra",
                            SellPrice = 25.00m,
                            Title = "A Game of Thrones"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            CostPrice = 8.00m,
                            GenreId = 3,
                            IsSequel = true,
                            PageCount = 310,
                            PublicationYear = 1937,
                            Publisher = "HarperCollins",
                            SellPrice = 16.00m,
                            SequelId = 4,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            CostPrice = 5.00m,
                            GenreId = 4,
                            IsSequel = false,
                            PageCount = 256,
                            PublicationYear = 1934,
                            Publisher = "Collins Crime Club",
                            SellPrice = 10.00m,
                            Title = "Murder on the Orient Express"
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 5,
                            CostPrice = 7.50m,
                            GenreId = 5,
                            IsSequel = true,
                            PageCount = 454,
                            PublicationYear = 2003,
                            Publisher = "Doubleday",
                            SellPrice = 15.00m,
                            SequelId = 6,
                            Title = "The Da Vinci Code"
                        });
                });

            modelBuilder.Entity("BookStoreDB.Entities.BookPromotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("PromotionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("PromotionId");

                    b.ToTable("BookPromotion");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Discounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(2,0)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Epic Fantasy"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Thriller"
                        });
                });

            modelBuilder.Entity("BookStoreDB.Entities.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("DiscountPercentage")
                        .HasColumnType("decimal(2,0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Promotion");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Book", b =>
                {
                    b.HasOne("BookStoreDB.Entities.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreDB.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("BookStoreDB.Entities.BookPromotion", b =>
                {
                    b.HasOne("BookStoreDB.Entities.Book", "Book")
                        .WithMany("BookPromotions")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreDB.Entities.Promotion", "Promotion")
                        .WithMany("bookPromotion")
                        .HasForeignKey("PromotionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Promotion");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Discounts", b =>
                {
                    b.HasOne("BookStoreDB.Entities.Book", "book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Book", b =>
                {
                    b.Navigation("BookPromotions");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreDB.Entities.Promotion", b =>
                {
                    b.Navigation("bookPromotion");
                });
#pragma warning restore 612, 618
        }
    }
}
