using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PetsController : ControllerBase
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();
    [HttpGet]
    public List<Pet> ViewAllPets()
    {
      return db.Pets.ToList();
    }
    [HttpGet("{id}")]
    public Pet ViewPetById(int id)
    {
      var pet = new Pet();
      return pet = db.Pets.FirstOrDefault(p => p.Id == id);
    }
    [HttpPost]
    public Pet AddAPet(Pet newPet)
    {
      db.Pets.Add(newPet);
      db.SaveChanges();
      return newPet;
    }
    [HttpPatch("{id}/play")]
    public Pet PlayWithPet(int id)
    {
      var playPet = db.Pets.FirstOrDefault(p => p.Id == id);
      playPet.HappinessLevel = playPet.HappinessLevel + 5;
      playPet.HungerLevel = playPet.HungerLevel + 3;
      db.SaveChanges();
      return playPet;
    }
    [HttpPatch("{id}/feed")]
    public Pet FeedAPet(int id)
    {
      var feedPet = db.Pets.FirstOrDefault(p => p.Id == id);
      feedPet.HappinessLevel = feedPet.HappinessLevel + 3;
      feedPet.HungerLevel = feedPet.HungerLevel - 5;
      db.SaveChanges();
      return feedPet;
    }
    [HttpPatch("{id}/scold")]
    public Pet ScoldAPet(int id)
    {
      var scoldPet = db.Pets.FirstOrDefault(p => p.Id == id);
      scoldPet.HappinessLevel = scoldPet.HappinessLevel - 5;
      db.SaveChanges();
      return scoldPet;
    }
    [HttpDelete("{id}")]
    public Pet DeleteAPet(int id)
    {
      var killPet = db.Pets.FirstOrDefault(p => p.Id == id);
      db.Pets.Remove(killPet);
      db.SaveChanges();
      return killPet;
    }
  }
}