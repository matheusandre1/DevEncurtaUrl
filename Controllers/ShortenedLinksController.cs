using DevEncurtaUrl.Entities;
using DevEncurtaUrl.Models;
using DevEncurtaUrl.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevEncurtaUrl.Controllers
{
    [ApiController]
    [Route("api/shortenedLinks")]
    public class ShortenedLinksController : ControllerBase
    {
        private readonly DevEncurtaURLDBContext _context;

        public ShortenedLinksController(DevEncurtaURLDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Links);
        }

        [HttpGet("{id}")]

        public IActionResult GetByID(int id)
        {
            var link = _context.Links.SingleOrDefault(l => l.Id == id);

            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);
        }

        [HttpPost]

        public IActionResult Post(AddOrUptadeShortenedLinkModels model)
        {
            var link = new ShortenedCustomLink(model.Title, model.DestinationLink);

            _context.Links.Add(link);
            _context.SaveChanges();
            return CreatedAtAction("GetById", new { id = link.Id }, link);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, AddOrUptadeShortenedLinkModels model)
        {
            var link = _context.Links.SingleOrDefault(l => l.Id == id);
            if (link == null)
            {
                return NotFound();
            }

            link.Update(model.Title, model.DestinationLink);
            _context.Links.Update(link);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var link = _context.Links.SingleOrDefault(l => l.Id == id);
            if (link == null)
            {
                return NotFound(); 
            }
            _context.Links.Remove(link);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("/(code")]
        public IActionResult RedirectLink(string code) 
        {
            var link = _context.Links.SingleOrDefault(l =>l.Code == code);
            if (link == null)
            {
                return NotFound();
            }
            return Redirect(link.DestinationLink);
        }
    }
}
