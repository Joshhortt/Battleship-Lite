// IV -Wire up the logic
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

				if (doesGameContinue == true)  // 17. Add if else condition if the game continues is true than do ..
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

			IdentifyWinner(winner);    // 21. Add to Create method from here

			Console.ReadLine();
		}

		private static void IdentifyWinner(PlayerInfoModel winner) 
		{
			Console.WriteLine($"Congratulations to {winner.UserName} for winning!");  
			Console.WriteLine($"{ winner.UserName } took { GameLogic.GetShotCount(winner) } shots.");   	                                                                                           
		}

		private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponentPlayer)
		{
			bool isValidShot = false;  
			string row = "";          
			int column = 0;         

			do
			{
				string shot = AskForShot(); 

				// Determine what row and columnms that is  - split it apart
				(row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);  
																		    
				// Determine if that is a valid result	
				isValidShot = GameLogic.ValidateShot(activePlayer, row, column);  

				// Show a warning message
				if (isValidShot == false) 
				{
					Console.WriteLine("Invalid Shot Location. Please try again! ");  
				}

				// Go back to the beginning if not a valid shot
			} while (isValidShot == false);

			// Determine shot results
			bool isAHit = GameLogic.IdentifyShowResult(opponentPlayer, row, column);  

			// Record results 
			GameLogic.MarkShotResult(activePlayer, row, column, isAHit);  
		}

		private static string AskForShot()  
		{
			Console.Write("Please enter your shot selection: "); 
			string output = Console.ReadLine();  

			return output; 
		}

		private static void DisplayShotGrid(PlayerInfoModel activePlayer)
		{
			string currentRow = activePlayer.ShotGrid[0].SpotLetter;  

			foreach (var gridSpot in activePlayer.ShotGrid) 
			{
				if (gridSpot.SpotLetter != currentRow)
				{
					Console.WriteLine();  
					currentRow = gridSpot.SpotLetter; 
				}

				if (gridSpot.Status == GridSpotStatus.Empty) 
				{
					Console.Write($" { gridSpot.SpotLetter } { gridSpot.SpotNumber } "); 
				}
				else if(gridSpot.Status == GridSpotStatus.Hit)  
				{
					Console.Write(" X ");  
				}
				else if(gridSpot.Status == GridSpotStatus.Miss) 
				{
					Console.Write(" O ");  
				}
				else
					Console.Write(" ? "); 
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
