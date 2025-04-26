using Microsoft.AspNetCore.Mvc;
using RestAPIWithApsNet8.Model;
using RestAPIWithApsNet8.Services.Implementations;
using System;
using System.Globalization;

namespace RestAPIWithApsNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
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
        public IActionResult Post([FromBody] Person person)
        {     
            if (person == null) return BadRequest("Person Invalid");
            return Ok(_personService.Create(person));
        }[HttpPut]
        public IActionResult Put([FromBody] Person person)
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
