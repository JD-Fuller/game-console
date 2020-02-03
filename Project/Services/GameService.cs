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
      // var fannyPack = _game.CurrentPlayer.Inventory;
      // string bossRoom = "Dragon Room Lair 3000";
      // bool b = fannyPack.Contains(bossRoom);
      // if (_game.CurrentRoom.Name == bossRoom)
      // {
      // }

      var roomItem = _game.CurrentRoom.Items;
      System.Console.Clear();
      Messages.Clear();
      Messages.Add(_game.CurrentRoom.Name + " " + _game.CurrentRoom.Description);
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
      Messages.Add("Welcome to the Return of the Planet of the Apes at Hogwarts School of Witchcraft and Wizardry for the Fellowship of the Rings of the Immaculate heart of the Sisters of Sonic the Hedgehog, I am Link, I will be your guide.");
      System.Console.WriteLine("Enter 'Restart' at anytime to restart your game");
      System.Console.WriteLine("");
      System.Console.WriteLine("Enter 'Help' to see a menu of options");
    }

    public void Setup(string playerName)
    {
      Messages.Clear();
      System.Console.Clear();
      _game.CurrentPlayer.Name = playerName;
      Messages.Add("");
      Messages.Add($"Hello Jedi Knight Wizard Slayer Renegade of Funk, who also goes by.... {_game.CurrentPlayer.Name}");
      Messages.Add("");
      Messages.Add($"You are currently in the {_game.CurrentRoom.Name}.");
      Messages.Add("Be weary and take caution in this place. Something smells fishy....could be the tuna salad someone had for lunch earlier.");
      Messages.Add("");
      Messages.Add("Enter 'Restart' at anytime to restart your game");
      Messages.Add("");
      Messages.Add("Enter 'Help' to see a menu of options");
      // Messages.Add("Enter 'help' for a list of actions you can take while you are on your quest");
      // Messages.Add("Enter 'help' for a  menu, or 'play' if you are a baller and don't care about the rules...honey badger.");
      // Messages.Add("");
      // Messages.Add("Enter 'restart' to reignite your quest from the beginning.");
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
      var item = roomItem.Find(i => i.Name.ToLower() == itemName);
      if (item != null)
      {
        fannyPack.Add(item);
        roomItem.Clear();
        System.Console.WriteLine($"You have done well for yourself. The {itemName} is now yours. Thievery is always a respectable occupation.");
      }
      // }
    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      var activeRoomName = _game.CurrentRoom.Name;
      var fannyPack = _game.CurrentPlayer.Inventory;
      var roomItem = _game.CurrentRoom.Items;


      var item = fannyPack.Find(i => i.Name.ToLower() == itemName);

      if (item != null)
      {
        // if (activeRoomName.ToLower() != "dragon room lair 3000")
        // {
        //   System.Console.Clear();
        //   Messages.Clear();
        //   Messages.Add("You can't use that item in this room. Try hitting the batting cages and maybe you'll be able to see your pitches in the 9th inning better");
        // }

        if (_game.CurrentRoom.useables.ContainsKey(item))
        {
          _game.CurrentRoom.Description = _game.CurrentRoom.useables[item];

          fannyPack.Remove(item);
          roomItem.Add(item);
        }
        else
        {
          Messages.Add("Item has no use here...moron.");
        }

        // if (fannyPack.Exists(i => i.Name.ToLower() != itemName))
        // {
        //   System.Console.Clear();
        //   Messages.Clear();
        //   Messages.Add("This item is not in your inventory --- Choose another item.");
        // }

        if ((activeRoomName.ToLower() == "dragon room lair 3000") && (itemName.ToLower() == "louisville slugger"))
        {
          System.Console.Clear();
          Messages.Clear();
          Messages.Add($"You have defeated the treacherous energy vampire dragon with the {itemName}, your name will be known throughout the land....Well, that's about it...heh...we don't have a reward or anything, so, shoo, shoo, get out of here!");
          Messages.Add("Enter 'Quit' or 'Q' to end game.");
          Messages.Add("Enter 'Restart' or 'R' to reset game.");
          return;
        }
        else if ((activeRoomName.ToLower() == "dragon room lair 3000") && (itemName.ToLower() != "louisville slugger"))
        {
          System.Console.Clear();
          Messages.Clear();
          Messages.Add($"You have upset the Demogorgon with your lack of Baseball skills - your quest is over and you are now vanquished from the realm. GAME OVER!");
          Messages.Add("Enter 'Quit' or 'Q' to end game.");
          Messages.Add("Enter 'Restart' or 'R' to reset game.");
          return;
        }
      }
      else
      {
        Messages.Add("Enter Valid Item");
      }



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


