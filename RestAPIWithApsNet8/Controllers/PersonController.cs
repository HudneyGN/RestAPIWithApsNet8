using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithApsNet8.Business;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonBusiness _personService;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound("Person Invalid");
            return Ok(person);
        }
        [HttpPost]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Person Invalid");
            return Ok(_personService.Create(person));
        }
        [HttpPut]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Person Invalid");
            return Ok(_personService.Update(person));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
