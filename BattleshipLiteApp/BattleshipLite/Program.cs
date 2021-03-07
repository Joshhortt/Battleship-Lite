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
				DisplayShotGrid(activePlayer);  // 5. DisplayAShotGrid of activePlayer. 
			                                    // Create method from here, in here adding in User Interface logic (program.cs)

				// Ask activePlayer for a shot
				// Determine if it is a valid shot
				// Determine shot results
				RecordPlayerShot(activePlayer, opponentPlayer);  // 14. RecordPlayerShot of activePlayer & opponentPlayer. 
																//Create method from here, in here adding in User Interface logic (program.cs)

				// Determine if the game is over
				bool doesGameContinue = GameLogic.PlayerStillActive(opponentPlayer);  // 16. Add boolean if game continues. 
				                                                                      // Create method from here in 'GameLogic.cs'

				// If over set activePlayer as the winner
				// else, swap positions (activePlayer to opponentPlayer)

				if(doesGameContinue == true)  // 17. Add if else condition if the game continues is true than do ..
				{
				    // ### Swap using a 'temp variable' * (before  C# 7.0 way of doing) ###
					//PlayerInfoModel tempHolder = opponentPlayer;  // 19. Add temp variable these 3 lines of code.
					//opponentPlayer = activePlayer;
					//activePlayer = tempHolder;

					// ### *New way of doing this. Use 'Tuple'(after  C# 7.0 way of doing) ###
					(activePlayer, opponentPlayer) = (opponentPlayer, activePlayer);  // 20. Flip them around
				}
				else
				{
					winner = activePlayer;  // 18. if false then the winner is the activePlayer 

				}
			} while (winner == null);

			Console.ReadLine();
		}

		private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponentPlayer)
		{
			// 15. Delete throw new NotImplementedException();

			// ### We will crete here some kind of loop.....###

			// Asks for a shot (we ask for 'B2')
			// Determine what row and columnms that is  - split it apart
			// Determinde if taht is a valid resulrt
			// Go back to the beginning if not a valid shot
			// Determine shot results
			// Record results 
 		}

		private static void DisplayShotGrid(PlayerInfoModel activePlayer)
		{
			string currentRow = activePlayer.ShotGrid[0].SpotLetter;  // 10. create variabe

			// 6. Delete throw new NotImplementedException();

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
					Console.Write(" X ");  
				}
				else if(gridSpot.Status == GridSpotStatus.Miss)  // 12. adds a  o that's a miss
				{
					Console.Write(" O ");  
				}
				else
					Console.Write(" ? ");  // 13. add question mark, means something is wrong
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
