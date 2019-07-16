using Microsoft.AspNetCore.Mvc;
using BookNS.Models;
using BookNS.Models.BindingTargets;
using System.Collections.Generic;

namespace BookNS.Controllers
{
    [Route("api/publishers")]
    public class PublisherController : Controller
    {
        private DataContext context;
        public PublisherController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IEnumerable<Publisher> GetPublishers()
        {
            return context.Publishers;
        }

        [HttpPost]
        public IActionResult CreatePublisher([FromBody] PublisherData pdata)
        {
            if (ModelState.IsValid)
            {
                Publisher p = pdata.Publisher;
                context.Add(p);
                context.SaveChanges();
                return Ok(p.PublisherId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplacePublisher(long id,
               [FromBody] PublisherData sdata)
        {
            if (ModelState.IsValid)
            {
                Publisher p = sdata.Publisher;
                p.PublisherId = id;
                context.Update(p);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePublisher(long id)
        {
            context.Remove(new Publisher { PublisherId = id });
            context.SaveChanges();
            return Ok(id);
        }
    }
}
