using System.Collections.Generic;

namespace BookNS.Models
{
    public class Book
    {
        public long BookId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Writer { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Publisher Publisher { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}