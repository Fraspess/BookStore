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
    }
}
