using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class BookOrders
    {
        public int Id { get; set; }

        public string CustomerName{get;set;}

        public int BookId { get; set; }

        public int AccountId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
