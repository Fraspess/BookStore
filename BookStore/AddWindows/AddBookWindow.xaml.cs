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
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private BookStore context = new BookStore();
        public AddBookWindow()
        {
            InitializeComponent();
            AuthorComboBox.ItemsSource = context.authors.ToList();
            GenreComboBox.ItemsSource = context.genres.ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(AuthorComboBox.Text == null)
            {
                MessageBox.Show("Select an author!");
                return;
            }


                var newBook = new Book
                {
                    Title = TitleBox.Text,
                    Publisher = PublisherBox.Text,
                    PublicationYear = int.Parse(YearBox.Text),
                    CostPrice = int.Parse(CostBox.Text),
                    SellPrice = int.Parse(SellBox.Text),
                    IsSequel = IsSequelCheckBox.IsChecked == true,
                    PageCount = int.Parse(PageCountBox.Text),
                    AuthorId = (int)(AuthorComboBox.SelectedValue),
                    GenreId = (int)(GenreComboBox.SelectedValue)

                };
                context.books.Add(newBook);
                context.SaveChanges();
                MessageBox.Show("Book added successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);


                //MessageBox.Show("Error" + ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);

        }
    }
}
