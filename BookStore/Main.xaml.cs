using BookStoreDB;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows;
using BookStoreDB.Entities;
using BookStoreDB.ViewWpf;
using System.Collections.ObjectModel;

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

            cb.ItemsSource = new List<string>() { "", "Books","Authors","Genres","Promotions","Discounts" };
            
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
                        var books = context.books
                            .Include(b => b.Author)
                            .Include(b => b.Genre)
                            .Select(b=>new BookViewWpf
                            {
                                Id = b.Id,
                                Title = b.Title,
                                Publisher = b.Publisher,
                                PublicationYear = b.PublicationYear,
                                CostPrice = b.CostPrice,
                                SellPrice = b.SellPrice,
                                IsSequel = b.IsSequel,
                                PageCount = b.PageCount,
                                Author = b.Author.FullName,
                                Genre = b.Genre.Name
                                
                            })
                            .ToList();
                        DbTable.ItemsSource = books;
                        
                        break;
                    }
                case "Authors":
                    {
                        var authors = context.authors
                           .Include(a => a.Books)
                           .AsNoTracking()
                           .ToList()
                           .Select(a => new AuthorViewWpf
                           {
                               Id = a.Id,
                               FullName = a.FullName,
                               Books = a.Books.Select(b => new BookViewWpf
                               {
                                   Title = b.Title,
                                   Publisher = b.Publisher,
                                   PublicationYear = b.PublicationYear,
                                   IsSequel = b.IsSequel
                               }).ToList()
                           }).ToList();
                        DbTable.ItemsSource = authors.ToList();


                        break;
                    }
                case "Genres":
                    {
                        DbTable.ItemsSource = context.genres.ToList();
                        break;
                    }
                case "Promotions":
                    {
                        DbTable.ItemsSource = context.promotions.ToList();
                        break;   
                    }
                case "Discounts":
                    {
                        DbTable.ItemsSource = context.discounts.ToList();
                        break;
                    }

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
