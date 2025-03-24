using BookStoreDB;
using BookStoreDB.Entities;
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

namespace BookStoreApp.AddWindows
{
    /// <summary>
    /// Interaction logic for AddGenre.xaml
    /// </summary>
    public partial class AddGenre : Window
    {
        private BookStore context = new BookStore();
        public AddGenre()
        {
            InitializeComponent();
        }

        private void AddGenreButton_Click(object sender, RoutedEventArgs e)
        {
            BooksBox.ItemsSource = context.books.ToList();

            string genreName = GenreName.Text;

            var existingGenre = context.genres.Select(g => g.Name == genreName);

            if(existingGenre == null)
            {
                var newGenre = new Genre()
                {
                    Name = genreName,
                    Books = (ICollection<Book>)BooksBox.SelectedValue
                };
                context.genres.Add(newGenre);
                context.SaveChanges();
                MessageBox.Show("Successfully added new genre","Success",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Genre already exists");
                
            }

        }
    }
}
