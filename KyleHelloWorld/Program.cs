using System;
using System.Collections.Generic;
using System.Linq;

namespace KyleHelloWorld
{
	class Program
	{
		public static void Main()
		{
			List<Player> players = new List<Player>
			{
				new Player { Name = "Kyle" },
				new Player { Name = "Mason" },
				new Player { Name = "Jake" },
			};

			Dictionary<string, int> bodyParts = new Dictionary<string, int>();
			bodyParts.Add("Head", 100);
			bodyParts.Add("Arm", 50);
			bodyParts.Add("Leg", 75);

			Console.WriteLine("Kyle Text Shooter");
			Console.WriteLine("press any key to start");
			Console.ReadKey();

			while (true) //this is the main game loop
			{
				Console.WriteLine("Who do you want to shoot? Remaining players: " + string.Join(", ", players.Select(p => p.Name)));
				string shotPerson = Console.ReadLine();

				Console.WriteLine("What body part do you want to shoot?");
				string shotBodyPart = Console.ReadLine();

				if (bodyParts.ContainsKey(shotBodyPart) == false)
				{
					Console.WriteLine("Invalid body part.");
					continue;
				}

				var shotPlayer = players.SingleOrDefault(p => p.Name.ToUpper() == shotPerson.ToUpper());
				if (shotPlayer == null)
				{
					Console.WriteLine("You didn't shoot anyone.");
				}
				else
				{
					shotPlayer.Health = shotPlayer.Health - bodyParts[shotBodyPart];
					Console.WriteLine($"You shot {shotPlayer.Name}. They have {shotPlayer.Health}% health remaining.");
					if (shotPlayer.Health <= 0)
					{
						Console.WriteLine($"You killed: {shotPlayer.Name}");
						players.Remove(shotPlayer);
					}

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
