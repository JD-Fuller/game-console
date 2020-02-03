using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Controllers
{

  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();
    private bool _playing = true;

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.Clear();
      Console.WriteLine("Welcome to the North Jon Snow. Forget everything you know, and you might just make it out alive.");
      Console.WriteLine("This will be the toughest, simple challenge you'll do all morning......probably, we can't really guarantee that.");

      while (_playing)
      {
        Print();
        GetUserInput();
      }
      Console.Clear();
      Console.WriteLine("Your quest has been fairly okay...not really something you want to write home about.");
    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("");
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"

      Console.Clear();
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          break;
        case "help":
          _gameService.Help();
          break;
        case "use":
          _gameService.UseItem(option);
          break;
        case "quit":
          Console.Clear();
          _playing = false;
          break;
        case "take":
          Console.Clear();
          _gameService.TakeItem(option);
          break;
        case "inventory":
          Console.Clear();
          _gameService.Inventory();
          break;
        case "look":
          Console.Clear();
          _gameService.Look();
          break;
        default:
          System.Console.WriteLine("Those words mean nothing here, try again.");
          break;
      }
    }

    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (var message in _gameService.Messages)
      {
        Console.WriteLine(message);
      }

    }

  }
}