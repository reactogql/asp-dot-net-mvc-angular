using System.ComponentModel.DataAnnotations;
namespace BookNS.Models.BindingTargets
{
    public class PublisherData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        public Publisher Publisher => new Publisher
        {
            Name = Name,
            City = City,
            State = State
        };
    }
}
