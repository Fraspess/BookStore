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
    /// Interaction logic for ShowDiscounts.xaml
    /// </summary>
    public partial class ShowDiscounts : Window
    {
        BookStore context = new BookStore();
        public ShowDiscounts()
        {
            InitializeComponent();

            var discounts = context.discounts
                .Include(d => d.book)
                .Select(d => new DiscountsViewWpf
                {
                    Id = d.Id,
                    Discount = d.Discount,
                    StartDate = d.StartDate,
                    EndDate = d.EndDate,
                    BookId = d.BookId
                }).ToList();
            DbTable.ItemsSource = discounts.ToList();
        }
    }
}
