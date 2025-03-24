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
    /// Interaction logic for AddDiscount.xaml
    /// </summary>
    public partial class AddDiscount : Window
    {
        private BookStore context = new BookStore();
        public AddDiscount()
        {
            InitializeComponent();
        }

        private void AddDiscountButton_Click(object sender, RoutedEventArgs e)
        {
            Books.ItemsSource = context.books.ToList();
            try
            {
            var newDiscount = new Discounts
            {
                Discount = int.Parse(Discount.Text),
                BookId = (int)Books.SelectedValue,
                StartDate = DateTime.Parse(StartDate.Text),
                EndDate = DateTime.Parse(EndDate.Text)
            };

            context.discounts.Add(newDiscount);
            context.SaveChanges();
            MessageBox.Show("Successfully added discount");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }


        }
    }
}
