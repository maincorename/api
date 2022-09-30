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
    [Route("api/v1/persons")]
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
        /// <returns>200 - удалился, 400 - не удалился.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var person = await _context.Persons.Include(p => p.Skills)
                                               .FirstAsync(p => p.Id.Equals(id));
            if (person != null)
            {
                _context.Remove(person);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else return BadRequest();
        }

        /// <summary>
        /// Получить всех сотрудников.
        /// </summary>
        /// <returns> Список сотрудников. </returns>
        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var persons = await _context.Persons.Include(p => p.Skills)
                                                .ToListAsync();
            return new ObjectResult(persons);
        }

        /// <summary>
        /// Получить сотрудника по Id.
        /// </summary>
        /// <param name="id"> Id сотрудника. </param>
        /// <returns> Найденный сотрудник. </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(long id)
        {
            var person = await _context.Persons.Include(p => p.Skills)
                                               .FirstAsync(p => p.Id.Equals(id));
            if (person == null)
                return BadRequest();
            return new ObjectResult(person);
        }

        /// <summary>
        /// Добавить сотрудника в базу.
        /// </summary>
        /// <param name="person">Сотрудник.</param>
        /// <returns>201 - добавился, 400 - не добавился.</returns>
        [HttpPost]
        public async Task<ActionResult> Post(Person person)
        {
            if (person != null)
            {
                _context.Persons.Add(person);
                await _context.SaveChangesAsync();
                return Ok(StatusCode(201));
            } 
            else return BadRequest();
        }

        /// <summary>
        /// Изменить сотрудника в базе.
        /// </summary>
        /// <param name="id"> Id сотрудника. </param>
        /// <param name="person"> Сотрудник. </param>
        /// <returns>201 - добавился, 400 - не изменился.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, Person person)
        {
            var currentPerson = await _context.Persons.FindAsync(id);
            if (currentPerson != null)
            {
                currentPerson.DisplayName = person.DisplayName;
                currentPerson.Name = person.Name;
                currentPerson.Skills = person.Skills;

                _context.Update(currentPerson);
                await _context.SaveChangesAsync();
                return Ok(StatusCode(201));
            }
            else return BadRequest();
            
        }
    }
}