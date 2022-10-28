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

    // GET api/places/
    [HttpGet]
    public async Task<List<Animal>> Get(string country, string name, int rating)
    {
      IQueryable<Animal> query = _db.Animals.Include(entry => entry.Reviews).AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name).Include(entry => entry.Reviews);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country).Include(entry => entry.Reviews);
      }

      if (rating > 0)
      {
        query = query.Where(entry => entry.Rating == rating).Include(entry => entry.Reviews);
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
      IQueryable<Animal> quer = _db.Animals.Include(entry => entry.Reviews).AsQueryable();
      quer = quer.Where(entry => entry.AnimalId == id).Include(entry => entry.Reviews);
      return await quer.ToListAsync();
    }
  
    // GET api/places/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Animal>>> GetAnimal(int id)
    {
      IQueryable<Animal> place = _db.Animals.Include(entry => entry.Reviews).AsQueryable();
      place = place.Where(entry => entry.AnimalId == id).Include(entry => entry.Reviews);
      if (id > _db.Animals.Count())
      {
        return NotFound();
      }
      return await place.ToListAsync();
    }

    // POST api/places
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal place)
    {
      _db.Animals.Add(place);
      await _db.SaveChangesAsync();

      // return CreatedAtAction("Post", new { id = place.AnimalId }, place);
      return CreatedAtAction(nameof(GetAnimal), new { id = place.AnimalId }, place);
    }

    // PUT: api/Animals/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal place)
    {
      if (id != place.AnimalId)
      {
        return BadRequest();
      }

      _db.Entry(place).State = EntityState.Modified;

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
      var place = await _db.Animals.FindAsync(id);
      if (place == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(place);
      await _db.SaveChangesAsync();

      return NoContent();
    }
    
    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }

    
  }
}