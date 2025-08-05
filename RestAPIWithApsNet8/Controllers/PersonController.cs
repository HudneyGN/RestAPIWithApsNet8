using System.Globalization;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestAPIWithApsNet8.Business;
using RestAPIWithApsNet8.Data.VO;
using RestAPIWithApsNet8.Hypermedia.Filters;
using RestAPIWithApsNet8.Model;

namespace RestAPIWithApsNet8.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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

        [HttpGet("{sortDirection}/{pagesize}/{page}")]
        [ProducesResponseType(typeof(List<PersonVO>), StatusCodes.Status200OK)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery] string name, string sortDirection, int pageSize, int page)
        {
            return Ok(_personService.FindWithPagedSearch(sortDirection, sortDirection, pageSize, page));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status200OK)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound("Person Invalid");
            return Ok(person);
        } 
        [HttpGet("findPersonByName")]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status200OK)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get([FromQuery]string firstName, string lastName)
        {
            var person = _personService.FindByName(firstName, lastName);
            if (person == null) return NotFound("Person Invalid");
            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Person Invalid");
            return Ok(_personService.Create(person));
        }

        [HttpPut]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody] PersonVO person)
        {
            if (person == null) return BadRequest("Person Invalid");
            return Ok(_personService.Update(person));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(PersonVO), StatusCodes.Status200OK)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Patch(long id)
        {
            var person = _personService.Disable(id);
            return Ok(person);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        //[TypeFilter(typeof(HyperMediaFilter))] delete não precisa
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
