using BookStoreDB;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows;
using BookStoreDB.Entities;
using BookStoreDB.ViewWpf;
using System.Collections.ObjectModel;
using System.Diagnostics;
using BookStoreApp.ShowWindows;
using System.Windows.Controls;
using BookStoreApp.AddWindows;

namespace BookStoreApp
{


    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>

    
    public partial class Main : Window
    {

        BookStore context = new BookStore();
        
        public Main()
        {
            InitializeComponent();

            cb.ItemsSource = new List<string>() { "", "Books","Authors","Genres","Discounts" };
            
        }

        private void ShowButton_Click(object sender, RoutedEventArgs e)
        {
            

            switch(cb.Text)
            {
                case "":
                    MessageBox.Show("Choose a table to show");
                    break;

                case "Books":
                    {
                        ShowBooks showBooks = new ShowBooks();
                        showBooks.Show();
                        //var books = context.books
                        //    .Include(b => b.Author)
                        //    .Include(b => b.Genre)
                        //    .Select(b=>new BookViewWpf
                        //    {
                        //        Id = b.Id,
                        //        Title = b.Title,
                        //        Publisher = b.Publisher,
                        //        PublicationYear = b.PublicationYear,
                        //        CostPrice = b.CostPrice,
                        //        SellPrice = b.SellPrice,
                        //        IsSequel = b.IsSequel,
                        //        PageCount = b.PageCount,
                        //        Author = b.Author.FullName,
                        //        Genre = b.Genre.Name
                                
                        //    })
                        //    .ToList();
                        //DbTable.ItemsSource = books;
                        
                        break;
                    }
                case "Authors":
                    {
                        ShowAuthors showAuthors = new ShowAuthors();
                        showAuthors.Show();

                        //foreach (var author in authors)
                        //{
                        //    Debug.WriteLine($"Author: {author.FullName}, Books Count: {author.Books.Count}");
                        //    foreach (var book in author.Books)
                        //    {
                        //        Debug.WriteLine($"Book: {book.Title}");
                        //    }
                        //}

                        break;
                    }
                case "Genres":
                    {
                        ShowGenres showGenres = new ShowGenres();
                        showGenres.Show();
                        break;
                    }
                case "Discounts":
                    {
                        ShowDiscounts showDiscounts = new ShowDiscounts();
                        showDiscounts.Show();
                        
                        break;
                    }

            }
        }



        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch(cb.Text)
            {
                case "Books":
                    {
                        if (int.TryParse(cmd.Text, out int id))
                        {
                            var book = new Book{ Id = id};
                            context.books.Attach(book);
                            context.books.Remove(book);
                            context.SaveChanges();
                            MessageBox.Show("Successfully deleted");
                        }
                        
                        break;
                    }

                case "Authors":
                    {
                        if(int.TryParse(cmd.Text,out int id))
                        {
                            var author = new Author { Id = id };
                            context.authors.Attach(author);
                            context.authors.Remove(author);
                            context.SaveChanges();
                            MessageBox.Show("Successfully deleted");
                        }
                        break;
                    }
                case "Genres":
                    {
                        if(int.TryParse(cmd.Text,out int id))
                        {
                            var genre = new Genre { Id = id };
                            context.genres.Attach(genre);
                            context.genres.Remove(genre);
                            context.SaveChanges();
                            MessageBox.Show("Successfully deleted");
                        }
                        break;
                    }
                case "Discounts":
                    {
                        if(int.TryParse(cmd.Text,out int id))
                        {
                            var discount = new Discounts { Id = id };
                            context.discounts.Attach(discount);
                            context.discounts.Remove(discount);
                            context.SaveChanges();
                            MessageBox.Show("Successfully deleted");
                        }    
                        break;
                    }
            }
        }

        private void cmd_GotFocus(object sender, RoutedEventArgs e)
        {
            if(cmd.Text == "Enter id here to delete")
            {
                cmd.Text = "";
            }
        }

        private void cmd_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(cmd.Text))
            {
                cmd.Text = "Enter id here to delete";
            }
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            switch(cb.Text)
            {
                case "Books":
                    {
                        AddBookWindow addBook = new AddBookWindow();
                        addBook.Show();
                        break;
                    }
            }
        }
    }
}
