using System;
using System.Collections.Generic;
using System.Linq;

namespace KyleHelloWorld
{
	class Program
	{
		//This is the main function that executes by default in a console application
		public static void Main()
		{

			//This is going to be all the players in the system
			List<Player> players = new List<Player>
			{
				new Player { Name = "Kyle" },
				new Player { Name = "Mason" },
				new Player { Name = "Jake" },
			};

			//This is going to contain all the body parts we can shoot
			Dictionary<string, int> bodyParts = new Dictionary<string, int> 
			{
				{"Head", 100 },
				{"Arm", 50 },
				{"Leg", 75 },
			};

			//Title screen
			Console.WriteLine("Kyle Text Shooter");
			Console.WriteLine("press any key to start");
			Console.ReadKey();

			while (true) //this is the main game loop
			{
				Console.WriteLine("Who do you want to shoot? Remaining players: " + string.Join(", ", players.Select(p => p.Name)));
				string shotPerson = Console.ReadLine();

				Console.WriteLine("What body part do you want to shoot?");
				string shotBodyPart = Console.ReadLine();

				//Check to make sure body part entered is valid
				if (bodyParts.ContainsKey(shotBodyPart) == false)
				{
					Console.WriteLine("Invalid body part.");
					continue; //this skips the rest of the code in the while loop and restarts the while loop from the first line
				}

				//Get the shot player from our list of players. If there isn't one found that matches, then shotPlayer will be null
				var shotPlayer = players.SingleOrDefault(p => p.Name.ToUpper() == shotPerson.ToUpper());

				if (shotPlayer == null)
				{
					Console.WriteLine("You didn't shoot anyone.");
					continue;
				}
				else
				{
					//decrease the players health
					shotPlayer.Health = shotPlayer.Health - bodyParts[shotBodyPart];
					Console.WriteLine($"You shot {shotPlayer.Name}. They have {shotPlayer.Health}% health remaining.");

					//check if we killed the player
					if (shotPlayer.Health <= 0)
					{
						Console.WriteLine($"You killed: {shotPlayer.Name}");
						players.Remove(shotPlayer);
					}

					//if no players are remaining, tell the user and quit the program
					if (players.Count == 0)
					{
						Console.WriteLine("You killed everyone. The END; Press any key to exit.");
						Console.ReadKey();
						Environment.Exit(0);
					}
				}
			}
		}
	}
}
