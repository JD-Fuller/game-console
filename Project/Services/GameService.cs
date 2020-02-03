using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using System.Threading;
using ConsoleAdventure.Project.Models;
using System.Linq;

namespace ConsoleAdventure.Project
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }

    public List<string> Messages { get; set; } = new List<string>();
    public GameService()
    {
      _game = new Game();
      Messages = new List<string>();
    }
    public void Go(string direction)
    {
      if (_game.CurrentRoom.Exits.ContainsKey(direction))
      {
        System.Console.Clear();
        Messages.Clear();
        Timing(7);
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        Messages.Add($"You are now in the {_game.CurrentRoom.Name.ToString()} room.");
        Messages.Add("");
        Messages.Add($"{_game.CurrentRoom.Description}");
        return;

      }
    }
    public void Help()
    {
      System.Console.Clear();
      Messages.Clear();
      System.Console.WriteLine("---------------Quest Menu--------------");
      System.Console.WriteLine("");
      System.Console.WriteLine("Select 'go east' or 'go west' to travel between rooms");
      System.Console.WriteLine("");
      System.Console.WriteLine("Enter 'Look' to see items in a room");
      System.Console.WriteLine("");
      System.Console.WriteLine("Enter 'Take', followed by item to put item in your fannie pack.");
      System.Console.WriteLine("");
      System.Console.WriteLine("Enter 'Inventory' to see items in your fannie pack");
      System.Console.WriteLine("");
      System.Console.WriteLine("Enter 'Use', followed by item name to use item");
      System.Console.WriteLine("");
      System.Console.WriteLine("Enter 'Quit' to exit game");
      System.Console.WriteLine("");
      System.Console.WriteLine("Good luck!");
      return;

    }

    public void Inventory()
    {
      System.Console.Clear();
      Messages.Clear();
      // var fannyPack = _game.CurrentPlayer.Inventory;
      System.Console.WriteLine($"Total Count of Items in Fannie Pack: {_game.CurrentPlayer.Inventory.Count}");
      Messages.Add("*****---------------------------*****");
      Messages.Add("*****------Fannie Pack Gear List:");

      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        Messages.Add($"{item.Name}---->{item.Description}");
      }
      return;
    }


    public void Look()
    {
      var fannyPack = _game.CurrentPlayer.Inventory;
      string bossRoom = "Dragon Room Lair 3000";
      bool b = fannyPack.Contains(bossRoom);

      if (_game.CurrentRoom.Name == bossRoom)
      {

      }

      var roomItem = _game.CurrentRoom.Items;
      System.Console.Clear();
      Messages.Clear();
      Messages.Add($"This room contains {roomItem.Count} item(s).");
      foreach (var item in roomItem)
      {
        Messages.Add($"Items List: {item.Name}---->{item.Description}");
      }
    }

    public void Quit()
    {
      System.Console.Clear();
      // System.Console.WriteLine("Stay Alert mortal");
      Messages.Clear();
      Messages.Add("Some people aren't cut out for quests. Fare thee well on the jourey home.");
      return;
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      System.Console.Clear();
      Messages.Clear();
      Messages.Add("You have chosen to reset this voyage.");
      _game.Setup();
    }

    public void Setup(string playerName)
    {
      throw new System.NotImplementedException();
    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Messages.Clear();
      System.Console.Clear();

      var fannyPack = _game.CurrentPlayer.Inventory;
      var roomItem = _game.CurrentRoom.Items;

      // if (roomItem.Count == 0)
      // {
      //   Messages.Add("Trix are for kids, there's no item in this room.");
      // }
      // else
      // {

      var item = roomItem.Find(i => i.Name == itemName);
      fannyPack.Add(item);
      roomItem.Clear();
      System.Console.WriteLine($"You have done well for yourself. The {itemName} is now yours. Thievery is always a respectable occupation.");
      // }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      // bool isInList = false;

      // for (int i = 0; i < _game.CurrentPlayer.Inventory.Count; i++)
      // {
      //   if (_game.CurrentPlayer.Inventory[i].Name == itemName)
      //   {
      //     _game.CurrentPlayer.Inventory.RemoveAt[i];
      //     break;
      //     //  _game.CurrentPlayer.Inventory[I].quantity += quantity;
      //     isInList = true;
      //     if (isInList == true)
      //     {
      //     Messages.Add("Item Used...sort of");
    }

    private static void Timing(int time)
    {
      for (int i = 0; i < time; i++)
      {
        System.Console.Write(".");
        Thread.Sleep(250);
      }
    }
  }
}


