using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BookNS.Models;

namespace BookNS
{

    public class SeedData
    {

        public static void SeedDatabase(DataContext context)
        {
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.Books.Count() == 0)
            {
                var s1 = new Publisher
                {
                    Name = "Packt-pub",
                    City = "San Jose",
                    State = "CA"
                };
                var s2 = new Publisher
                {
                    Name = "Apress",
                    City = "Chicago",
                    State = "IL"
                };
                var s3 = new Publisher
                {
                    Name = "SAS Institute",
                    City = "New York",
                    State = "NY"
                };

                context.Books.AddRange(
                    new Book
                    {
                        Image = "bit.ly/2CL6JsO",
                        Title = "Titanic",
                        Description = "A 17-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                        Category = "Drama",
                        Price = 75,
                        Publisher = s1,
                        Writer = "Jeff Arson",
                        Ratings = new List<Rating> {
                            new Rating { Stars = 4 }, new Rating { Stars = 3 }}
                    },
                    new Book
                    {
                        Image = "bit.ly/2CLuDnP",
                        Title = "The Godfather",
                        Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son",
                        Category = "Drama",
                        Price = 48.95m,
                        Publisher = s1,
                        Writer = "John Parziale",
                        Ratings = new List<Rating> {
                            new Rating { Stars = 2 }, new Rating { Stars = 5 }}
                    },
                    new Book
                    {
                        Image = "bit.ly/2CM080Y",
                        Title = "Team America",
                        Description = "Broadway actor Gary Johnston is recruited by the elite counter-terrorism organization",
                        Category = "Comedy",
                        Price = 19.50m,
                        Publisher = s2,
                        Writer = "Leona Coffing",
                        Ratings = new List<Rating> {
                            new Rating { Stars = 1 }, new Rating { Stars = 3 }}
                    },
                    new Book
                    {
                        Image = "bit.ly/2CNWtjd",
                        Title = "Wedding Crashers",
                        Description = "Committed womanizers sneak into weddings to take advantage of the romantic tinge in the air",
                        Category = "Comedy",
                        Price = 34.95m,
                        Publisher = s2,
                        Writer = "Veljko Packheiser",
                        Ratings = new List<Rating> { new Rating { Stars = 3 } }
                    },
                    new Book
                    {
                        Image = "bit.ly/2CJrZix",
                        Title = "Superbad",
                        Description = "Two co-dependent high school seniors are forced to deal with separation anxiety after their plan to stage a booze-soaked party goes awry",
                        Category = "Comedy",
                        Price = 70,
                        Publisher = s2,
                        Writer = "Sim Clitherow",
                        Ratings = new List<Rating> { new Rating { Stars = 1 },
                            new Rating { Stars = 4 }, new Rating { Stars = 3 }}
                    },
                    new Book
                    {
                        Image = "bit.ly/2CLVMag",
                        Title = "Bridget Jones's Diary",
                        Description = "A British woman is determined to improve herself while she looks for love in a year in which she keeps a personal diary.",
                        Category = "Romance",
                        Price = 16,
                        Publisher = s3,
                        Writer = "Jitendra Cooper",
                        Ratings = new List<Rating> { new Rating { Stars = 5 },
                            new Rating { Stars = 4 }}
                    },
                    new Book
                    {
                        Image = "bit.ly/2CLuLDP",
                        Title = "Love Actually",
                        Description = "Eight very different couples deal with their love lives",
                        Category = "Romance",
                        Price = 29.95m,
                        Publisher = s3,
                        Writer = "John Danthine",
                        Ratings = new List<Rating> { new Rating { Stars = 3 } }
                    },
                    new Book
                    {
                        Image = "bit.ly/2CLuO2t",
                        Title = "The Way We Were",
                        Description = "Two desperate people have a wonderful romance, but their political views and convictions drive them apart.",
                        Category = "Romance",
                        Price = 75,
                        Writer = "Morgan Holland",
                        Publisher = s3
                    },
                    new Book
                    {
                        Image = "bit.ly/2CMG4vx",
                        Title = "Ghost",
                        Description = "After a young man is murdered, his spirit stays behind to warn his lover of impending danger, with the help of a reluctant psychic.",
                        Category = "Romance",
                        Price = 10,
                        Publisher = s3,
                        Writer = "Jack Triantis"
                    });
                context.SaveChanges();
            }
        }
    }
}