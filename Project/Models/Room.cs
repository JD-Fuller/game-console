using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }

    public Room EastRoom { get; set; }
    public Room WestRoom { get; set; }

    public Dictionary<Item, string> useables { get; set; }

    public void ChangeRoom()
    {

    }

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
      useables = new Dictionary<Item, string>();


    }
  }
}