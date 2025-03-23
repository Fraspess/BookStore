using BookStoreDB;
using BookStoreDB.Entities;
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
    /// Interaction logic for ShowAuthors.xaml
    /// </summary>
    public partial class ShowAuthors : Window
    {
        BookStore context = new BookStore();
        public ShowAuthors()
        {
            InitializeComponent();

            var authors = context.authors
                          .Include(a => a.Books)
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
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in DbTable.Items)
            {
                if (item is AuthorViewWpf updatedAuthor)
                {
                    var authorInDb = context.authors.FirstOrDefault(b => b.Id == updatedAuthor.Id);
                    if (authorInDb != null)
                    {
                        authorInDb.FullName = updatedAuthor.FullName;
                        authorInDb.Books = updatedAuthor.Books.Select(b =>
                        {
                            var existingBook = context.books.FirstOrDefault(x => x.Title == b.Title);
                            if (existingBook != null)
                            {
                                existingBook.Publisher = b.Publisher;
                                existingBook.PublicationYear = b.PublicationYear;
                                existingBook.IsSequel = b.IsSequel;
                                existingBook.CostPrice = b.CostPrice;
                                existingBook.SellPrice = b.SellPrice;
                                existingBook.PageCount = b.PageCount;
                                return existingBook; 
                            }
                            else
                            {
                                var genre = context.genres.FirstOrDefault(g => g.Id == b.GenreId);
                                if (genre == null)
                                {
                                    MessageBox.Show($"Помилка: Жанр із ID {b.GenreId} не існує!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return null;
                                }

                                return new Book
                                {
                                    Title = b.Title,
                                    Publisher = b.Publisher,
                                    PublicationYear = b.PublicationYear,
                                    IsSequel = b.IsSequel,
                                    CostPrice = b.CostPrice,
                                    SellPrice = b.SellPrice,
                                    PageCount = b.PageCount,
                                    Genre = genre 
                                };
                            }
                        }).Where(b => b != null).ToList();
                    }
                }
            }
     
                context.SaveChanges();
                MessageBox.Show("Database updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
   

        }
    }
}
