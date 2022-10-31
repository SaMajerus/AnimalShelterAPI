using System;
using System.Collections.Generic;
using System.Linq; 
// using System.Data.Entity;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // GET api/animals/
    [HttpGet]
    public async Task<List<Animal>> Get(string name, string dogOrCat, int age)
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (dogOrCat != null)
      {
        query = query.Where(entry => entry.Type == dogOrCat);
      }

      if (age > 0)
      {
        query = query.Where(entry => entry.Age == age);
      }

      return await query.ToListAsync();
    }

    [HttpGet("random")]
    public async Task<ActionResult<IEnumerable<Animal>>> GetRandom()
    {
      int lower = 1;
      int upper = _db.Animals.Count() + 1;
      Random rnd = new Random();
      int id = rnd.Next(lower, upper);
      IQueryable<Animal> quer = _db.Animals.AsQueryable();
      quer = quer.Where(entry => entry.AnimalId == id);
      return await quer.ToListAsync();
    } 
  
    // GET api/animals/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal(int id)
    {
      IQueryable<Animal> animal = _db.Animals.AsQueryable();
      animal = animal.Where(entry => entry.AnimalId == id);
      if (id > _db.Animals.Count())
      {
        return NotFound();
      }
      return await animal.ToListAsync();
    }

    // POST api/animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = animal.AnimalId }, animal);
      // return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(animal).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    // DELETE: api/Animals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    
  }
}