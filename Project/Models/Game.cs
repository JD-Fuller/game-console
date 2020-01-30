using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    public void Setup()
    {
      //Data Setup
      Player js = new Player("Jon Snow", new string[] { "Sword", "Brooding Look", "Direwolf" });
      Player ph = new Player("Pee Wee Herman", new string[] { "Yo-Yo", "Laugh", "Genie" });
      Player tr = new Player("T-Rex", new string[] { "Teeth", "Tiny Arms", "Laser" });

      Item wood_sword = new Item("Sword of Wood", "It's a sword...that's made from wood.");
      Item shield = new Item("Shield of Oak", "Shield made from Magic Oak Tree");
      Item magic_map = new Item("Maurauder's Map", "A map that some guy named Potter left here");
      Item ipod = new Item("Magic Mystery Ipod", "This device takes you on a journey");
      Item wizard_pepper = new Item("Wizard Pepper", "You don't even want to know what this does...just don't take it if you plan on going somewhere and need to not look like you've just ingested 100 grams of LSD");
      Item carbon_baton = new Item("Carbon Fiber Baton", "It's for twirling");
      Item mjolnir = new Item("Vial of Thor", "Vial of juice from the stray dog outside the castle - has a yellow-ish hue and pungent smell");
      Item cloak = new Item("Vampire cloak", "It's for parties and special occasions");
      Item skateboard = new Item("Tony Hawks Skateboard", "Legend Maker");
      Item pbnj = new Item("Peanut Butter and Jelly Sandwhich", "Food of the Gods");
      Item lildeb = new Item("Little Debbie Snack Cakes - Zebra", "Ancient food of the gladiators");
      Item witchfur = new Item("Old dingy black cat", "This thing won't leave the castle. It has no powers that we know of and it won't leave. Please, take it from us, seriously, this thing is annoying.");
      Item baseballbat = new Item("Louisville Slugger", "For crushing homers");


      Room td = new Room("ThunderDome Foyer", "This is the first room. There is a door to the East.");
      Room wr = new Room("Wizard Room", "This is the second room. There are two doors - one to the east, and one to the west.");
      Room gr = new Room("Goblin Room", "This is the third room. There are two doors - one to the east, and one to the west.");
      Room dr = new Room("Dragon Room Lair 3000", "This is the fourth room. There is one door in this room, and you just walked through it (Behind you to the west.");

      //Add Exits to each Room
      td.AddExit(wr);
      wr.AddExit(td);
      wr.AddExit(gr);
      gr.AddExit(wr);
      gr.AddExit(dr);
      dr.AddExit(gr);

      //Add Items to Rooms
      td.Items.Add(new Item(magic_map.Name, magic_map.Description));
      wr.Items.Add(new Item(baseballbat.Name, baseballbat.Description));
      gr.Items.Add(new Item(wizard_pepper.Name, wizard_pepper.Description));
      dr.Items.Add(new Item(lildeb.Name, lildeb.Description));

      CurrentRoom = td;
      CurrentPlayer = js;
    }

    public Game()
    {
      Setup();
    }
  }
}