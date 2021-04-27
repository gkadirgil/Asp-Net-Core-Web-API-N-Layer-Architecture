using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Model;
using NLayerProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IServicesGeneric<Person> _servicesGeneric;

        public PersonsController(IServicesGeneric<Person> servicesGeneric)
        {
            _servicesGeneric = servicesGeneric;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _servicesGeneric.GetAllAsync();

            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newPerson =await _servicesGeneric.AddAsync(person);

            return Created(string.Empty, newPerson);
        }
    }
}
