using Microsoft.AspNetCore.Mvc;
using BookNS.Models;
using BookNS.Models.BindingTargets;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;

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

        [HttpGet]
        public IEnumerable<Book> GetBooks(string category, string search,
                                            bool related = false)
        {
            IQueryable<Book> query = context.Books;
            if (!string.IsNullOrWhiteSpace(category))
            {
                string catLower = category.ToLower();
                query = query.Where(m => m.Category.ToLower().Contains(catLower));
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(m => m.Title.ToLower().Contains(searchLower)
                || m.Description.ToLower().Contains(searchLower));
            }

            if (related)
            {
                query = query.Include(m => m.Publisher).Include(m => m.Ratings);
                List<Book> data = query.ToList();
                data.ForEach(m =>
                {
                    if (m.Publisher != null)
                    {
                        m.Publisher.Books = null;
                    }
                    if (m.Ratings != null)
                    {
                        m.Ratings.ForEach(r => r.Book = null);
                    }
                });
                return data;
            }
            else
            {
                return query;
            }
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] BookData mdata)
        {
            if (ModelState.IsValid)
            {
                Book m = mdata.Book;
                // if (m.Publisher != null && m.Publisher.PublisherId != 0)
                if (m.Publisher != null && m.Publisher.PublisherId != 0)
                {
                    context.Attach(m.Publisher);
                }
                context.Add(m);
                context.SaveChanges();
                return Ok(m.BookId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceBook(long id, [FromBody] BookData mData)
        {
            if (ModelState.IsValid)
            {
                Book m = mData.Book;
                m.BookId = id;
                if (m.Publisher != null && m.Publisher.PublisherId != 0)
                {
                    context.Attach(m.Publisher);
                }
                context.Update(m);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


        [HttpPatch("{id}")]
        public IActionResult UpdateBook(long id,
           [FromBody] JsonPatchDocument<BookData> patch)
        {
            Book book = context.Books
            .Include(m => m.Publisher)
            .First(m => m.BookId == id);
            // MovieData mdata = new MovieData { Movie = movie };
            BookData mdata = new Book { Book = book };
            patch.ApplyTo(mdata, ModelState);
            if (ModelState.IsValid && TryValidateModel(mdata))
            {
                if (book.Publisher != null && book.Publisher.PublisherId != 0)
                {
                    context.Attach(book.Publisher);
                }
                context.SaveChanges();
                return Ok(book);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(long id)
        {
            context.Books.Remove(new Book { BookId = id });
            context.SaveChanges();
            return Ok(id);
        }
    }




}