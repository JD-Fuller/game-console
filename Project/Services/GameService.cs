using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using System.Threading;
using ConsoleAdventure.Project.Models;

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
        // System.Console.WriteLine("Stay Alert mortal");
        Messages.Clear();
        Timing(7);
        _game.CurrentRoom = _game.CurrentRoom.Exits[direction];
        Messages.Add($"You are now in the {_game.CurrentRoom.Name.ToString()} room.");
        Messages.Add("");
        Messages.Add("Stay Alert and look around");
        return;

      }
    }
    public void Help()
    {
      throw new System.NotImplementedException();
    }

    public void Inventory()
    {
      throw new System.NotImplementedException();
    }

    public void Look()
    {
      throw new System.NotImplementedException();
    }

    public void Quit()
    {
      throw new System.NotImplementedException();
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
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
      throw new System.NotImplementedException();
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