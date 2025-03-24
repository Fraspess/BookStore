using BookStoreDB;
using BookStoreDB.ViewWpf;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookStoreApp.ShowWindows
{
    /// <summary>
    /// Interaction logic for ShowBooks.xaml
    /// </summary>
    public partial class ShowBooks : Window
    {
        BookStore context = new BookStore();
        public ShowBooks()
        {
            InitializeComponent();

            var books = context.books
                            .Include(b => b.Author)
                            .Include(b => b.Genre)
                            .Select(b => new BookViewWpf
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
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in DbTable.Items)
            {
                if (item is BookViewWpf updatedBook)
                {
                    var bookInDb = context.books.FirstOrDefault(b => b.Id == updatedBook.Id);
                    if (bookInDb != null)
                    {
                        bookInDb.Title = updatedBook.Title;
                        bookInDb.Publisher = updatedBook.Publisher;
                        bookInDb.PublicationYear = updatedBook.PublicationYear;
                        bookInDb.CostPrice = updatedBook.CostPrice;
                        bookInDb.SellPrice = updatedBook.SellPrice;
                        bookInDb.IsSequel = updatedBook.IsSequel;
                        bookInDb.PageCount = updatedBook.PageCount;
                    }
                }
            }
            try
            {
                context.SaveChanges(); 
                MessageBox.Show("Database updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            var books = context.books
                           .Include(b => b.Author)
                           .Include(b => b.Genre)
                           .Select(b => new BookViewWpf
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
                           .OrderByDescending(b=>b.SellPrice)
                           .ToList();
            DbTable.ItemsSource = books;
        }
    }
}
