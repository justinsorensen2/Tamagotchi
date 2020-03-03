using System;
using System.Linq;
using Tamagotchi.Models;

namespace Tamagotchi
{
  public class Pet
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime Birthday { get; set; }
    public int HungerLevel { get; set; }
    public int HappinessLevel { get; set; }
    public bool IsDead { get; set; } = false;
    public DateTime DeathDate { get; set; } = DateTime.Now;
    public DateTime LastInteractedWith { get; set; } = DateTime.Now;

  }
}