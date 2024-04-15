namespace APBD_task4;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private static List<Animal> animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Buddy", Category = "Dog", Weight = 25.5, FurColor = "Brown" },
        new Animal { Id = 2, Name = "Whiskers", Category = "Cat", Weight = 8.2, FurColor = "Gray" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals()
    {
        return Ok(animals);
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimalById(int id)
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }
        return Ok(animal);
    }

    [HttpPost]
    public ActionResult<Animal> AddAnimal(Animal animal)
    {
        animal.Id = animals.Count + 1; // Simulate auto-increment ID
        animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var existingAnimal = animals.FirstOrDefault(a => a.Id == id);
        if (existingAnimal == null)
        {
            return NotFound();
        }

        existingAnimal.Name = animal.Name;
        existingAnimal.Category = animal.Category;
        existingAnimal.Weight = animal.Weight;
        existingAnimal.FurColor = animal.FurColor;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        animals.Remove(animal);
        return NoContent();
    }

    [HttpGet("{id}/visits")]
    public ActionResult<IEnumerable<Visit>> GetVisitsForAnimal(int id)
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        return Ok(animal.Visits);
    }

    [HttpPost("{id}/visits")]
    public ActionResult<Visit> AddVisitForAnimal(int id, Visit visit)
    {
        var animal = animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound();
        }

        visit.Id = animal.Visits.Count + 1; // Simulate auto-increment ID
        animal.Visits.Add(visit);
        return CreatedAtAction(nameof(GetVisitsForAnimal), new { id = id }, visit);
    }
}
