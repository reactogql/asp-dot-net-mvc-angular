using Microsoft.AspNetCore.Mvc;
using BookNS.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BookNS.Controllers
{
    [Route("api/books")]
    public class BookController : Controller
    {
        private DataContext context;
        public BookController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Book GetBook(long id)
        {
            // return context.Books.Find(id);
            // .OrderBy(b => b.BookId).First();
            Book res = context.Books
               .Include(m => m.Publisher).ThenInclude(p => p.Books)
               .Include(m => m.Ratings)
               .FirstOrDefault(m => m.BookId == id);

            if (res != null)// break circular ref
            {
                if (res.Publisher != null)
                {
                    res.Publisher.Books = res.Publisher.Books.Select(p =>
                        new Book
                        {
                            BookId = p.BookId,
                            Title = p.Title,
                            Writer = p.Writer,
                            Category = p.Category,
                            Description = p.Description,
                            Price = p.Price
                        }
                    );
                }
                if (res.Ratings != null)
                {
                    foreach (Rating r in res.Ratings)
                        r.Book = null;
                }
            }

            return res;
        }
    }
}