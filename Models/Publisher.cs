using System.Collections.Generic;

namespace BookNS.Models
{
    public class Publisher
    {

        public long PublisherId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}