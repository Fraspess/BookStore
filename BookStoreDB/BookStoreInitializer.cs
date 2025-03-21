using BookStoreDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB
{
    public static class BookStoreInitializer
    {
        public static void seedAccounts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account[]
            {
                new Account()
                {
                    Login = "admin",
                    Password = "admin",
                    Id = -1
                },
                new Account()
                {
                    Login = "user",
                    Password = "user",
                    Id = -2
                }
            });
        }

        public static void seedBooksAndAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author()
                {
                    Id = 1,
                    FullName = "J.K. Rowling"
                },
                new Author()
                {
                    Id = 2,
                    FullName = "George R.R. Martin"
                },
                new Author()
                {
                    Id = 3,
                    FullName = "J.R.R. Tolkien"
                },
                new Author()
                {
                    Id = 4,
                    FullName = "Agatha Christie"
                },
                new Author()
                {
                    Id = 5,
                    FullName = "Dan Brown"
                }
            });


            modelBuilder.Entity<Book>().HasData(new Book[]
           {
                new Book()
                {
                    Id = 1,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Publisher = "Bloomsbury",
                    PublicationYear = 1997,
                    CostPrice = 10.00m,
                    SellPrice = 20.00m,
                    IsSequel = true,
                    PageCount = 309,
                    AuthorId = 1,
                    GenreId = 1,
                    SequelId = 2
                },
                new Book()
                {
                    Id = 2,
                    Title = "A Game of Thrones",
                    Publisher = "Bantam Spectra",
                    PublicationYear = 1996,
                    CostPrice = 12.50m,
                    SellPrice = 25.00m,
                    IsSequel = false,
                    PageCount = 694,
                    AuthorId = 2,
                    GenreId = 2,
                    SequelId = null
                },
                new Book()
                {
                    Id = 3,
                    Title = "The Hobbit",
                    Publisher = "HarperCollins",
                    PublicationYear = 1937,
                    CostPrice = 8.00m,
                    SellPrice = 16.00m,
                    IsSequel = true,
                    PageCount = 310,
                    AuthorId = 3,
                    GenreId = 3,
                    SequelId = 4
                },
                new Book()
                {
                    Id = 4,
                    Title = "Murder on the Orient Express",
                    Publisher = "Collins Crime Club",
                    PublicationYear = 1934,
                    CostPrice = 5.00m,
                    SellPrice = 10.00m,
                    IsSequel = false,
                    PageCount = 256,
                    AuthorId = 4,
                    GenreId = 4,
                    SequelId = null
                },
                new Book()
                {
                    Id = 5,
                    Title = "The Da Vinci Code",
                    Publisher = "Doubleday",
                    PublicationYear = 2003,
                    CostPrice = 7.50m,
                    SellPrice = 15.00m,
                    IsSequel = true,
                    PageCount = 454,
                    AuthorId = 5,
                    GenreId = 5,
                    SequelId = 6
                }
           });

        }
        public static void seedGenres(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre() { Id = 1, Name = "Fantasy" },
                new Genre() { Id = 2, Name = "Epic Fantasy" },
                new Genre() { Id = 3, Name = "Adventure" },
                new Genre() { Id = 4, Name = "Mystery" },
                new Genre() { Id = 5, Name = "Thriller" }
            });
        }
        }
}
