using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithApsNet8.Business;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Hypermedia.Filters;
using RestAPIWithApsNet8.Model;
using Swashbuckle.AspNetCore.Annotations;

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
        [ProducesResponseType(typeof(List<BooksVO>), StatusCodes.Status200OK)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_bookservice.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BooksVO), StatusCodes.Status200OK)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var book = _bookservice.FindById(id);
            if (book == null) return NotFound("Book Invalid");
            return Ok(book);
        }
        [HttpPost]
        [ProducesResponseType(typeof(BooksVO), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] BooksVO book)
        {
            if (book == null) return BadRequest("Book Invalid");
            return Ok(_bookservice.Create(book));
        }
        [HttpPut]
        [ProducesResponseType(typeof(BooksVO), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] BooksVO book)
        {
            if (book == null) return BadRequest("Book Invalid");
            return Ok(_bookservice.Update(book));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _bookservice.Delete(id);
            return NoContent();
        }
    }
}
