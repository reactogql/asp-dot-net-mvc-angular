using System.ComponentModel.DataAnnotations;

namespace BookNS.Models.BindingTargets
{
    public class BookData
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get; set; }
        public long Publisher { get; set; }

        public Book Book => new Book
        {
            Title = Title,
            Category = Category,
            Description = Description,
            Price = Price,
            Writer = Writer,
            Publisher = Publisher == 0 ? null : new Publisher { PublisherId = Publisher }
        };
    }
}
