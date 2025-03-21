using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }


        public string Publisher { get; set; }

        public int PublicationYear { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SellPrice { get; set; }

        public bool IsSequel { get; set; }


        public int PageCount { get; set; }


        public int AuthorId { get; set; }
        public int GenreId { get; set; }

        public int? SequelId { get; set; }



        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public IEnumerable<BookPromotion> BookPromotions{ get; set; }


    }
}
