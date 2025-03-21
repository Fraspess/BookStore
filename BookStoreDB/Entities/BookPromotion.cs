using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class BookPromotion
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }
    }
}
