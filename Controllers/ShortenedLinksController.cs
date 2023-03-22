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
            var link =_context.Links.SingleOrDefault(l => l.Id == id);

            if(link  == null)
            {
                return NotFound();
            }
        }

        [HttpPost]

        public IActionResult Post(AddOrUptadeShortenedLinkModels model)
        {
            var link = new ShortenedCustomLink(model.Title, model.DestinationLink);

            _context.AddLink(link);
            return Ok(link);
        }

    }
}
