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
    /// Interaction logic for ShowGenres.xaml
    /// </summary>
    public partial class ShowGenres : Window
    {
        BookStore context = new BookStore();
        public ShowGenres()
        {
            InitializeComponent();

            var genres = context.genres
                .Include(g => g.Books)
                .Select(g => new GenresViewWpf
                {
                    Id = g.Id,
                    Name = g.Name,
                    Books = g.Books.Select(b => new BookViewWpf
                    {
                        Title = b.Title
                    }).ToList()

                }).ToList();


            DbTable.ItemsSource = genres;
                
            
        }
    }
}
