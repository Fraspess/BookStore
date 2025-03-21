using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class Discounts
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public decimal Discount{get;set;}

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Book book { get; set; }


    }
}
