//II - Add new project Console Aplication

using BattleshipLiteLibrary;
using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite
{
	class Program
	{
		static void Main(string[] args)
		{
			WelcomeMessage();    // 3. calling the Welcome Message from the Method

			PlayerInfoModel player1 = CreatePlayer("Player 1");  // 29. Create player 1
			PlayerInfoModel player2 = CreatePlayer("Player 2");  // 30. Create player 2


			Console.ReadLine(); //  1. add this right after creating new project.
		}

		private static void WelcomeMessage()  // 2.Method WelcomeMessager
		{
			// Hit F5 - Message print out to screen
			Console.WriteLine("Welcome to Battleship Lite");
			Console.WriteLine("Created by Josh Hortt");
			Console.WriteLine();
		}
		private static PlayerInfoModel CreatePlayer(string playerTitle)  // 4. Add another method. Add also reference BattleshipLiteLibrary, 
													                     //and add using BattleshipLiteLibrary.Models on top;
																		 // 31. Add parameters to CreatePlayer
		{
			PlayerInfoModel output = new PlayerInfoModel();  // 5. add new Instance

			Console.WriteLine($"Player Information {playerTitle}");  // 32. Add player Info of player 1 or player 2.

			// Ask the user for their name
			output.UserName = AskForUsersName();

			// Load up the shot grid
			GameLogic.InitializeGrid(output);  //18.  (cont.17 GameLogic)  remove output.ShotGrid =

			// Ask the user for their 5 ship placements
			PlaceShips(output);  // 26. Call method Placeships

			// Clear 
			Console.Clear();  // 27. Clear the screeen

			return output;   // 28. return the output
		}

		private static string AskForUsersName()  // 6. Add another string method. Asking users name and scope
		{
			Console.Write("What is your name: ");
			string output = Console.ReadLine();

			return output;
		}

		private static void PlaceShips(PlayerInfoModel model)  // 19. Add new method 
		{
			do  // 20. do' while' loop - If you have less than 5 ships keep going around
			{
				Console.Write($"Where do you want to place ship number { model.ShipLocations.Count + 1}: ");  // 21. Ask the user where they want to place ship
				string location = Console.ReadLine();     // 22. capture response


				bool isValidLocation = GameLogic.PlaceShip(model, location);   // 23. Generate a method from here that shows up in  class 'GameLogic.cs'. that returns a boolean
				if(isValidLocation == false)  // 24 . if statment if the location of ship is false, then ...
				{
					Console.WriteLine("That was not a valid location. Please try again. ");  // 25. Prompt the user validation is false, cannot place ship ther, to try again
				}
			} while (model.ShipLocations.Count < 5);
		}
	}
}
