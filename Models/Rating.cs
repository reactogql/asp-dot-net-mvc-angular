namespace BookNS.Models
{

    public class Rating
    {

        public long RatingId { get; set; }
        public int Stars { get; set; }
        public Book Book { get; set; }
    }
}