using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class Sales
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public DateTime SaleDate { get; set; }

        public int Quantity { get; set; }

        public int AccountId { get; set; }
    }
}
