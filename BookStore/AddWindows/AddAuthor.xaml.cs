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
    /// Interaction logic for AddAuthor.xaml
    /// </summary>
    
    public partial class AddAuthor : Window
    {
        private BookStore context = new BookStore();
        public AddAuthor()
        {
            InitializeComponent();
        }

        private void AddAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            string authorName = authorFullName.Text;

            if(string.IsNullOrWhiteSpace(authorName))
            {
                MessageBox.Show("Please enter valid author name");
                return;
            }

            var existingAuthor = context.authors.FirstOrDefault(a => a.FullName == authorName);
            if (existingAuthor == null)
            {
                var newAuthor = new Author { FullName = authorName };
                context.authors.Add(newAuthor);
                context.SaveChanges();
                MessageBox.Show("Author successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Author already exists");
            }

            
        }
    }
}
