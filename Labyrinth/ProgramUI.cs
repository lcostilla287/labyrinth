using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class ProgramUI
    {

        private ItemRepo _repo = new ItemRepo();
        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning) //same as while (keepRunning == true)
            {
                Console.Clear();
                Console.WriteLine("Please select a menu option:\n" +
                    "1. Start Game\n" +
                    "2. Exit");

                switch (Console.ReadLine().ToLower())
                {
                    case "1":
                    case "one":
                        GameStart(); //calling a method
                    break;
                    case "2":
                    case "two":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void GameStart()
        {
            Console.Clear();

            Console.WriteLine("Your best friends has been kidnapped.\n" +
                "To get them back, you need to traverse a labyrinth.\n" +
                "Be careful! It is very dangerous!");
            Console.ReadKey();

            Entrance();
        }

        //Entrance
        private void Entrance()
        {
            Console.Clear();
            
            Console.WriteLine("You are at the main entrance of the Labyrinth\n" +
                "What would you like to do?\n" +
                "1. Check the red door\n" +
                "2. Check suspicious red gnome\n" +
                "3. Check the suspicious red rock");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "one":
                    FrontDoor();
                    break;
                case "2":
                case "two":
                    LookLeft();
                    break;
                case "3":
                case "three":
                    LookRight();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    Entrance();
                    break;
            }
        }

        private void FrontDoor()
        {
            Console.Clear();
            Console.WriteLine("You try going through the red door.");
            Keys keyCheck = _repo.GetKeyByColor("Red");
            Console.ReadKey();
            if(keyCheck != null)
            {
                Console.WriteLine("You use the red key and it unlocks the door!\n" +
                    "You go through and enter the labyrinth.");
                //Doorsound
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\luis1\Desktop\ElevenFiftyProjects\Labyrinth\door_open.wav");
                player.Play();

                Console.ReadKey();
                RoomOne();
            }
            else
            {
                Console.WriteLine("You try opening the door but it's locked.\n" +
                    "You might need something to open it.");
                Console.ReadKey();
                Console.WriteLine("You decide to go back and look around");
                Console.ReadKey();
                Entrance();
            }
        }

        private void LookLeft()
        {
            Console.Clear();
            Console.WriteLine("You choose to take a closer look at the suspicious red gnome");
            Console.ReadKey();
            Console.WriteLine("You don't find anything.");
            Console.ReadKey();
            Console.WriteLine("You go back to the entrance");
            Console.ReadKey();
            Entrance();
        }
        private void LookRight()
        {
            Console.Clear();
            Console.WriteLine("You decide to take a closer look at the red rock.");
            Console.ReadKey();
            Keys keyCheck = _repo.GetKeyByColor("Red");

            if (keyCheck == null)
            {
                Keys newKey = new Keys();
                newKey.KeyColor = "Red";
                newKey.HasKey = true;

                bool wasAddedCorrectly = _repo.AddKeyToDirectory(newKey);

                if (wasAddedCorrectly)
                {
                    Console.WriteLine("You decide to turn the rock over and you find a Red Key!");
                    Console.ReadKey();
                    Console.WriteLine("You have obtained the Red Key!!");
                }
                else
                {
                    Console.WriteLine("You could't find anything.");
                }
            }
            else
            {
                Console.WriteLine("There is nothing here, you already have the key.");
            }

            Console.ReadKey();
            Entrance();
        }

        //Room One
        private void RoomOne()
        {
            Console.Clear();
            Console.WriteLine("You've entered the first room\n" +
                "What would you like to do?\n" +
                "1. Go into the dark hallway\n" +
                "2. Go into the hallway with lit torches");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "one":
                    GoLeft();
                    break;
                case "2":
                case "two":
                    GoStraight();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    RoomOne();
                    break;
            }
        }

        private void GoLeft()
        {
            Console.Clear();
            Console.WriteLine("You decide to go through the dark hallway.");
            Console.ReadKey();
            RoomTwo();
        }
        private void GoStraight()
        {
            Console.Clear();
            Console.WriteLine("You decide to go through the torch lit hallway.");
            Console.ReadKey();
            Console.WriteLine("You find a door.");
            Console.ReadKey();
            Console.WriteLine("The door is unlocked and you go into the next room.");
            Console.ReadKey();
            RoomThree();
        }
        //RoomTwo
        private void RoomTwo()
        {
            Console.Clear();
            Console.WriteLine("As you are walking down the dark hallway, you begin to think that it wasn't a good idea because you can't see.");
            Console.ReadKey();
            Console.WriteLine("You go back to the first room.");
            Console.ReadKey();
            RoomOne();
        }

        //Room Three\
        private void RoomThree()
        {
            Console.Clear();
            Console.WriteLine("You are in a torch lit room.\n" +
                "What would you like to do?\n" +
                "1. Go over the strange rope bridge\n" +
                "2. Go over floating stones\n" +
                "3. Go through the hallway filled with cobwebs");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "one":
                    RoomFour();
                    break;
                case "2":
                case "two":
                    RoomFive();
                    break;
                case "3":
                case "three":
                    RoomSix();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    RoomThree();
                    break;
            }
        }

        //Room Four
        private void RoomFour()
        {
            Console.Clear();
            Console.WriteLine("You decide to go over the shaky rope bridge");
            Console.ReadKey();

            Keys keyCheck = _repo.GetKeyByColor("Blue");

            if (keyCheck == null)
            {
                Keys newKey = new Keys();
                newKey.KeyColor = "Blue";
                newKey.HasKey = true;

                bool wasAddedCorrectly = _repo.AddKeyToDirectory(newKey);

                if (wasAddedCorrectly)
                {
                    Console.WriteLine("At the end of the bridge, you find a room with a Blue Key");
                    Console.ReadKey();
                    Console.WriteLine("You have obtained the Blue Key!!");
                }
                else
                {
                    Console.WriteLine("You could't obtain the key");
                }
            }
            else
            {
                Console.WriteLine("You ask yourself why you are doing this again, you already have the key.");
            }

            Console.ReadKey();
            Console.WriteLine("You go back to the previous room.");
            Console.ReadKey();
            RoomThree();
        }

        //Room Five
        private void RoomFive()
        {
            Console.Clear();
            Console.WriteLine("You carefully jump through the floating stones.");
            Keys keyCheck = _repo.GetKeyByColor("Blue");
            Console.ReadKey();
            if (keyCheck != null)
            {
                Console.WriteLine("You use the key to unlock the Blue door.");
                Console.ReadKey();
                //Doorsound
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\luis1\Desktop\ElevenFiftyProjects\Labyrinth\door_open.wav");
                player.Play();
                Console.WriteLine("The Blue door opens and you set your friend free!");

                Console.ReadKey();
                Console.WriteLine("He joins you to search for your other friend");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You find a locked Blue door.");
                Console.ReadKey();
                Console.WriteLine("You see a small opening through the door and you see your friend.");
                Console.ReadKey();
                Console.WriteLine("Your friend tells you that the key is past the rope bridge");
                Console.ReadKey();
            }
            Console.WriteLine("You go back to the previous room.");
            Console.ReadKey();
            RoomThree();
        }

        //Room Six
        private void RoomSix()
        {
            Console.Clear();
            Console.WriteLine("You have reached the next room. It is cold and dark.\n" +
                "What would you like to do?\n" +
                "1. Go through flooded hallway\n" +
                "2. Go through foggy hallway\n");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "one":
                    RoomEight();
                    break;
                case "2":
                case "two":
                    RoomSeven();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    RoomSix();
                    break;
            }
        }

        //Room Seven
        private void RoomSeven()
        {
            Console.Clear();
            Console.WriteLine("You are in a foggy room.\n" +
                "What would you like to do?\n" +
                "1. Use a rope to swing over a chasm\n" +
                "2. Go through partially collapsed hallway\n" +
                "3. Go Back");

            switch (Console.ReadLine().ToLower())
            {
                case "1":
                case "one":
                    RoomTen();
                    break;
                case "2":
                case "two":
                    RoomNine();
                    break;
                case "3":
                case "three":
                    RoomSix();
                    break;
                default:
                    Console.WriteLine("Please select a valid option");
                    Console.ReadKey();
                    RoomSeven();
                    break;
            }
        }

        //Room Eight
        private void RoomEight()
        {
            Console.Clear();
            Console.WriteLine("You traverse through the flooded hallway.");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\luis1\Desktop\ElevenFiftyProjects\Labyrinth\zapsplat_nature_water_deep_movement_surface_002_31724.wav");
            player.Play();
            Keys keyCheck = _repo.GetKeyByColor("Yellow");
            Console.ReadKey();
            if (keyCheck != null)
            {
                Console.WriteLine("You use the Yellow Key to unlock the Yellow door.");
                System.Media.SoundPlayer play = new System.Media.SoundPlayer(@"C:\Users\luis1\Desktop\ElevenFiftyProjects\Labyrinth\door_open.wav");
                play.Play();
                Console.ReadKey();
                //doorsound
                
                Console.WriteLine("You set your last friend free!");

                Console.ReadKey();
                Console.WriteLine("Congratulations! You have found your last friend and retrace your steps to the exit.");
                _repo.DeleteExistingKey("Red");
                _repo.DeleteExistingKey("Yellow");
                _repo.DeleteExistingKey("Blue");
                Console.ReadKey();
                
            }
            else
            {
                Console.WriteLine("You find a Yellow door and it's locked.");
                Console.ReadKey();
                Console.WriteLine("You wade through the flooded hallway back to the previous room");
                player.Play();
                Console.ReadKey();
                RoomSix();
            }

            
        }

        //Room Nine
        private void RoomNine()
        {
            Console.Clear();
            Console.WriteLine("As you are crawling through the partially collapsed hallway, it completely collapses!");
            Console.ReadKey();
            Console.Clear();
            _repo.DeleteExistingKey("Red");
            _repo.DeleteExistingKey("Yellow");
            _repo.DeleteExistingKey("Blue");
            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }

        //Room Ten
        private void RoomTen()
        {
            Console.Clear();
            Console.WriteLine("You decide to take a risk and swing over the chasm.");
            Keys keyCheck = _repo.GetKeyByColor("Yellow");

            if (keyCheck == null)
            {
                Keys newKey = new Keys();
                newKey.KeyColor = "Yellow";
                newKey.HasKey = true;

                bool wasAddedCorrectly = _repo.AddKeyToDirectory(newKey);

                if (wasAddedCorrectly)
                {
                    Console.WriteLine("You made it safely across!");
                    Console.ReadKey();
                    Console.WriteLine("You have found and obtained the Yellow Key!!");
                    Console.ReadKey();
                    Console.WriteLine("You swing back to the previous room.");
                    Console.ReadKey();
                    RoomSeven();
                }
                else
                {
                    Console.WriteLine("You could't obtain the key");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("The rope snaps!");
                System.Media.SoundPlayer play = new System.Media.SoundPlayer(@"C:\Users\luis1\Desktop\ElevenFiftyProjects\Labyrinth\zapsplat_foley_seed_pod_snap_break_flamboyant_tree_001_12034.wav");
                play.Play();
                Console.ReadKey();
                Console.Clear();
                _repo.DeleteExistingKey("Red");
                _repo.DeleteExistingKey("Yellow");
                _repo.DeleteExistingKey("Blue");
                Console.WriteLine("GAME OVER");
                Console.ReadKey();
            }       
        }
    }
}
