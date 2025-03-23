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
    }
}
