using BookStoreDB;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Windows;
using BookStoreDB.Entities;

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
                        DbTable.ItemsSource = context.books.ToList();
                        
                        break;
                    }
                case "Authors":
                    {


                        var authors = context.authors.Select(a => new
                        {
                            a.FullName,
                            Books = a.Books.Select(b => b.Title)

                        }).ToList();

                        DbTable.ItemsSource = authors;
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
