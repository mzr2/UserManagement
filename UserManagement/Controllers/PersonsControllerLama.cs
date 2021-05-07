using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Models;
using UserManagement.Repository;
using UserManagement.ViewModel;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsControllerLama : ControllerBase
    {
        private readonly PersonRepository personRepository;

        public object Firstname { get; private set; }

        public PersonsControllerLama(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        [HttpPost]
        [Route("Insert")]
        public ActionResult Insert(Person person)
        {
            try
            {
                return Ok(personRepository.Insert(person));
            }
            catch (Exception)
            {
                return StatusCode(405);
            }
        }

        [HttpPost("{Insert2}")]
        public ActionResult Insert2(Person person)
        {
            try
            {
                personRepository.Insert(person);
                return Ok(person);
            }
            catch (Exception)
            {
                return StatusCode(405);
            }
        }

        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Person> persons = personRepository.Get();
            if (persons.Count()>0)
            {
                return Ok(persons);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("{NIK}")]
        public ActionResult Get(string NIK)
        {
            try
            {
                Person persons = personRepository.Get(NIK);
                return Ok(persons);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        //[HttpGet]
        //public ActionResult GetFirstName(string FirstName)
        //{
        //    IEnumerable<Person> persons = personRepository.GetByFirstName(FirstName);
        //    return Ok(persons);
        //}

        [HttpGet]
        [Route("GetSalary2")]
        public ActionResult GetSalary2()
        {
            IEnumerable<PersonVM> persons = personRepository.GetSalary();
            if (persons.Count() > 0)
            {
                return Ok(persons);
            }
            else
            {
                return NotFound();
            }
        }
        
        [HttpGet("GetSalary/{NIK}")]
        public ActionResult GetSalary(string NIK)
        {
            try
            {
                PersonVM persons = personRepository.GetSalary(NIK);
                return Ok(persons);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public ActionResult Delete(string NIK)
        {
            Person persons = personRepository.Get(NIK);
            if (persons != null)
            {
                return Ok(personRepository.Delete(NIK));
            }
            else
            {
                return NotFound();
            }
            //try
            //{
            //    return Ok(personRepository.Delete(NIK));
            //}
            //catch (Exception)
            //{
            //    return NotFound();
            //}
        }

        [HttpPut]
        public ActionResult Update(Person person)
        {
            try
            {
                return Ok(personRepository.Update(person));
            }
            catch (Exception)
            {
                return StatusCode(405, new { status = HttpStatusCode.NotModified, message = "test"});
                //return NotFound();
            }
        }
    }
}
