using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreDB.Entities
{
    public class Promotion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal DiscountPercentage { get; set; }

        public ICollection<BookPromotion> bookPromotion { get; set; } = new HashSet<BookPromotion>();
    }
}
