// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using api.Entities;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [ApiController]
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        private readonly MyContext _context;

        public PeopleController(MyContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Удалить сотрудника по Id.
        /// </summary>
        /// <param name="id"> Id сотрудника. </param>
        /// <returns>True - удалился, false - не удалился.</returns>
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Remove(person);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Получить всех сотрудников.
        /// </summary>
        /// <returns> Список сотрудников. </returns>
        [HttpGet]
        public List<Person> Get()
        {
            var persons = _context.Persons;
            return persons.ToList();
        }

        /// <summary>
        /// Получить сотрудника по Id.
        /// </summary>
        /// <param name="id"> Id сотрудника. </param>
        /// <returns> Найденный сотрудник. </returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var persons = _context.Persons.Find(id);
            return Ok(persons);
        }

        /// <summary>
        /// Добавить сотрудника в базу.
        /// </summary>
        /// <param name="person">Сотрудник.</param>
        /// <returns>200 - добавился, 404 - не добавился.</returns>
        [HttpPost]
        public IActionResult Post(Person person)
        {
            if (person != null)
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
                return Ok();
            } 
            else return NotFound();
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Person person)
        {
            var currentPerson = _context.Persons.Find(id);
            currentPerson.DisplayName = person.DisplayName;
            currentPerson.Name = person.Name;
            currentPerson.Skills = person.Skills;

            _context.Update(currentPerson);
            _context.SaveChanges();
            return Ok();
        }
    }
}