using BookStoreDB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.ViewWpf
{
    public class BookViewWpf
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int PublicationYear { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellPrice { get; set; }
        public bool IsSequel { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }

        public int GenreId { get; set; }

    }
}
