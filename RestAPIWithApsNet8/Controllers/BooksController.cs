using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithApsNet8.Business;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private IBooksBusiness _bookservice;

        public BooksController(ILogger<BooksController> logger, IBooksBusiness bookService)
        {
            _logger = logger;
            _bookservice = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookservice.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookservice.FindById(id);
            if (book == null) return NotFound("Book Invalid");
            return Ok(book);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Books book)
        {
            if (book == null) return BadRequest("Book Invalid");
            return Ok(_bookservice.Create(book));
        }
        [HttpPut]
        public IActionResult Put([FromBody] Books book)
        {
            if (book == null) return BadRequest("Book Invalid");
            return Ok(_bookservice.Update(book));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookservice.Delete(id);
            return NoContent();
        }
    }
}
