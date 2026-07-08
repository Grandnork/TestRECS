using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly AppDbContext _context;

    // Dependency Injection
    public PeopleController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/people
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
    {
        var people = await _context.People.ToListAsync();

        return Ok(people);
    }
    /*
    Metodos separados, até tentei juntar por questões de leitura, mas lembrando que se trata de uma API
    e as questões do consumo dela, foi optado por dois endpoints diferentes.
    */
    // GET: api/people/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetPerson(Guid id)
    {
    var person = await _context.People.FindAsync(id);

    if (person == null)
    {
        return NotFound();
    }
    return Ok(person);
    }

    // POST: api/people
    [HttpPost]
    public async Task<ActionResult<Person>> CreatePerson(Person person)
    {
        _context.People.Add(person);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetPeople),
            new { id = person.Id },
            person
        );
    }

    // DELETE: api/people/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(Guid id)
    {
        var person = await _context.People.FindAsync(id);

        if (person == null)
        {
            return NotFound();
        }

        _context.People.Remove(person);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}