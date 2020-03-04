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
    public PetTracker tracker { get; set; } = new PetTracker();
    public DatabaseContext db { get; set; } = new DatabaseContext();
    [HttpGet]
    public List<Pet> ViewAllPets()
    {
      return db.Pets.ToList();
    }
    [HttpGet("{id}")]
    public Pet ViewPetById(int id)
    {
      var pet = db.Pets.FirstOrDefault(p => p.Id == id);
      pet.LastInteractedWith = DateTime.Now;
      var deadBool = tracker.Neglected(pet);
      while (pet.IsDead == false)
      {
        if (deadBool == true)
        {
          pet.IsDead = true;
          db.SaveChanges();
        }
        else
        {
          pet.LastInteractedWith = DateTime.Now;
          db.SaveChanges();
        }
      }
      return pet;
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
      var pet = db.Pets.FirstOrDefault(p => p.Id == id);
      var deadBool = tracker.SuddenPetDeathSyndrome();
      while (pet.IsDead == false)
      {
        if (deadBool == true)
        {
          pet.IsDead = true;
          db.SaveChanges();
        }
        else
        {
          pet.HappinessLevel += 5;
          pet.HungerLevel += 3;
          pet.LastInteractedWith = DateTime.Now;
          db.SaveChanges();
        }
      }
      return pet;
    }
    [HttpPatch("{id}/feed")]
    public Pet FeedAPet(int id)
    {
      var pet = db.Pets.FirstOrDefault(p => p.Id == id);
      pet.LastInteractedWith = DateTime.Now;
      var deadBool = tracker.SuddenPetDeathSyndrome();
      var neglectedBool = tracker.Neglected(pet);
      while (pet.IsDead == false)
      {
        if (deadBool == false && neglectedBool == false)
        {
          pet.HappinessLevel += 3;
          pet.HungerLevel -= 5;
          db.SaveChanges();
        }
        else
        {
          pet.IsDead = true;
          db.SaveChanges();
        }
      }
      return pet;

    }
    [HttpPatch("{id}/scold")]
    public Pet ScoldAPet(int id)
    {
      var pet = db.Pets.FirstOrDefault(p => p.Id == id);
      pet.LastInteractedWith = DateTime.Now;
      var deadBool = tracker.SuddenPetDeathSyndrome();
      var neglectedBool = tracker.Neglected(pet);
      while (pet.IsDead == false)
      {
        if (deadBool == false && neglectedBool == false)
        {
          pet.HappinessLevel -= 5;
          db.SaveChanges();
          return pet;
        }
        else
        {
          pet.IsDead = true;
          db.SaveChanges();
          return pet;
        }
      }
      return pet;
    }
    [HttpDelete("{id}")]
    public ActionResult DeleteAPet(int id)
    {
      var killPet = db.Pets.FirstOrDefault(p => p.Id == id);
      db.Pets.Remove(killPet);
      db.SaveChanges();
      return Ok();
    }
    [HttpGet("living")]
    public List<Pet> ViewLiving()
    {
      return db.Pets.Where(p => p.IsDead == false).ToList();
    }
  }
}