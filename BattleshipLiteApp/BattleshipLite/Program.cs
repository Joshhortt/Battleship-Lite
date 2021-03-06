// III - Console App Creation part2
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
			WelcomeMessage();    

			PlayerInfoModel activePlayer = CreatePlayer("Player 1");  // 3. Rename variable player1 to activePlayer
			PlayerInfoModel opponentPlayer = CreatePlayer("Player 2");  // 4. Rename variable player2 to opponentPlayer
			PlayerInfoModel winner = null;  // 1. Add variable

			do  // 2. do while Loop
			{

				// Display grid from activePlayer on where they fired
				DisplayShotGrid(activePlayer);  // 5. DisplayAShotGrid of activePlayer. Create method from here, in here adding in User Interface logic (program.cs)

				// Ask activePlayer for a shot
				// Determine if it is a valid shot
				// Determine shot results
				// Determine if the game is over
				// If over set activePlayer as the winner
				// else, swap positions (activePlayer to opponentPlayer)


			} while (winner == null);

			Console.ReadLine();
		}

		private static void DisplayShotGrid(PlayerInfoModel activePlayer)
		{
			string currentRow = activePlayer.ShotGrid[0].SpotLetter;  // 10. create variabe

			//throw new NotImplementedException(); 6. Delete throw .....

			foreach (var gridSpot in activePlayer.ShotGrid)  // 7.b add forech loop gridSpot in ShotGrid
			{
				if (gridSpot.SpotLetter != currentRow)  // 8.b add if statment
				{
					Console.WriteLine();  // 9.b add Console.WriteLine before you print ou 9. below
					currentRow = gridSpot.SpotLetter;  // 10. add update currentRow werever you are on
				}

				if (gridSpot.Status == GridSpotStatus.Empty)  // 8. add if statment
				{
					Console.Write($" { gridSpot.SpotLetter } { gridSpot.SpotNumber } ");  // 9. add Console.Write
				}
				else if(gridSpot.Status == GridSpotStatus.Hit)  // 11. adds a  x that's a hit
				{
					Console.WriteLine(" X ");  
				}
				else if(gridSpot.Status == GridSpotStatus.Miss)  // 12. adds a  o that's a miss
				{
					Console.WriteLine(" O ");  
				}
				else
					Console.WriteLine(" ? ");  // 13. add question mark, means something is wrong
			}
		}

		private static void WelcomeMessage() 
		{
			Console.WriteLine("Welcome to Battleship Lite");
			Console.WriteLine("Created by Josh Hortt");
			Console.WriteLine();
		}

		private static PlayerInfoModel CreatePlayer(string playerTitle)  
		{
			PlayerInfoModel output = new PlayerInfoModel();  

			Console.WriteLine($"Player Information {playerTitle}");

			output.UserName = AskForUsersName();

			GameLogic.InitializeGrid(output);  

			PlaceShips(output); 
 
			Console.Clear(); 

			return output;  
		}

		private static string AskForUsersName()  
		{
			Console.Write("What is your name: ");
			string output = Console.ReadLine();

			return output;
		}

		private static void PlaceShips(PlayerInfoModel model) 
		{
			do 
			{
				Console.Write($"Where do you want to place ship number { model.ShipLocations.Count + 1}: ");  
				string location = Console.ReadLine();   

				bool isValidLocation = GameLogic.PlaceShip(model, location);   
				if(isValidLocation == false) 
				{
					Console.WriteLine("That was not a valid location. Please try again. "); 
				}
			} while (model.ShipLocations.Count < 5);
		}
	}
}
