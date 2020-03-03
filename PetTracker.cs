using System;
using Tamagotchi.Models;

namespace Tamagotchi
{
  public class PetTracker
  {
    public DatabaseContext db { get; set; } = new DatabaseContext();
    public bool SuddenPetDeathSyndrome()
    {
      var killed = false;
      var sudden = new Random();
      var killer = sudden.Next(1, 101);
      if (killer <= 10)
      {
        killed = true;
      }
      return killed;
    }
    public bool Neglected(Pet pet)
    {
      var neglect = false;
      var date2 = pet.LastInteractedWith;
      var date1 = DateTime.Now;
      var difference = date1.Subtract(date2);
      var span = new TimeSpan(3, 0, 0, 0);
      if (difference >= span)
      {
        neglect = true;
      }
      else
      {
        neglect = false;
      }
      return neglect;
    }
  }
}