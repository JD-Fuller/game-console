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

      foreach (var item in _game.CurrentPlayer.Inventory)
      {
        System.Console.WriteLine($"Print this out {item}");
      }

      // var list = _game.CurrentPlayer.Inventory;


      // System.Console.WriteLine($"Total Count of Items in Fannie Pack: {_game.CurrentPlayer.Inventory.Count}");

      // if (_game.CurrentPlayer.Inventory != null)
      // {
      //   System.Console.WriteLine("Items In Fannie Pack: " + _game.CurrentPlayer.Inventory);
      //   list.ForEach(System.Console.WriteLine);
      //   System.Console.WriteLine(list);
      // }
    }

    public void Look()
    {
      System.Console.Clear();
      // System.Console.WriteLine("Stay Alert mortal");
      Messages.Clear();
      Messages.Add($"This room contains {_game.CurrentRoom.Items.Count} items.");
      Messages.Add($"Items List: {_game.CurrentRoom.Items}");
      return;
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
      if (_game.CurrentRoom.Items.Count == 0)
      {
        Messages.Add("Silly rabbit, trix are for kids - there are no items in this room");
        return;
      }
      Messages.Add($"Adding the following item, {_game.CurrentRoom.Items}, to your magic fannie pack.");
      _game.CurrentPlayer.Inventory.AddRange(_game.CurrentRoom.Items);
      _game.CurrentRoom.Items.Clear();
      Messages.Add($"The player now has {_game.CurrentPlayer.Inventory} in his possession.");
      Messages.Add($"The room now has {_game.CurrentRoom.Items.Count} items.");

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
