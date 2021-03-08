// V - Debugging & Testing
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

			PlayerInfoModel activePlayer = CreatePlayer("Player 1"); 
			PlayerInfoModel opponentPlayer = CreatePlayer("Player 2"); 
			PlayerInfoModel winner = null;  

			do 
			{
				DisplayShotGrid(activePlayer); 
			                                   
				RecordPlayerShot(activePlayer, opponentPlayer);   
				
				bool doesGameContinue = GameLogic.PlayerStillActive(opponentPlayer);  
																					 
				if (doesGameContinue == true)  
				{
					(activePlayer, opponentPlayer) = (opponentPlayer, activePlayer); 
				}
				else
				{
					winner = activePlayer; 
				}
			} while (winner == null);

			IdentifyWinner(winner);   

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
				string shot = AskForShot(activePlayer);  //   Debugging - 13. txt - 2. Pass in activePlayer

				try
				{
					(row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);  // Debugging - 02. Sourround these two lines with 'try' and 'catch'.
					isValidShot = GameLogic.ValidateShot(activePlayer, row, column);
				}
				catch (Exception)  // Debugging - 03. Add 'ex' to Exception
				{
					//throw;

					isValidShot = false;  // // Debugging - 04. Removed Error message and add bool
				}
					
				if (isValidShot == false)
				{
					Console.WriteLine("Invalid Shot Location. Please try again! ");
				}
			} while (isValidShot == false);

			bool isAHit = GameLogic.IdentifyShotResult(opponentPlayer, row, column);
		
			GameLogic.MarkShotResult(activePlayer, row, column, isAHit);
			DisplayShotResult(row, column, isAHit);   // Debugging - 16.txt -  3.  To tell us the result of the shot.
													  // Create method below
		}

		private static void DisplayShotResult(string row, int column, bool isAHit)   //  Debugging - 17.txt -  3. Method created from 16.
		{
			//throw new NotImplementedException();
			if(isAHit) // Debugging - 18.txt -  3.  if is it a hit
			{
				Console.WriteLine($"{ row } { column } is a Hit!"); // Debugging - 19.txt -  3.  string interpolation
			}
			else
			{
				Console.WriteLine($"{ row } { column } is a Miss!"); // Debugging - 20.txt -  3.  string interpolation
			}
			Console.WriteLine();  // Debugging - 3.  txt -  3. add blank line
		}

		private static string AskForShot(PlayerInfoModel player)  //   Debugging - 14. txt - 2. Pass in PlayerInfoModel player
		{
			Console.Write($"{player.UserName }, Please enter your shot selection: ");  //   Debugging - 15. txt - 2. Add string interpolation
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
			Console.WriteLine();  // Debugging - 11. txt - 1. After the grid displays, we need to empty lines. (Console.WriteLine)
			Console.WriteLine();  // Debugging - 12.txt -  1. After the grid displays, we need to empty lines. (Console.WriteLine)
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

				// bool isValidLocation = GameLogic.PlaceShip(model, location); Debugging - 05. Comment this
				bool isValidLocation = false;  // Debugging - 06. add bool isValidLocation to false

				try
				{
					isValidLocation = GameLogic.PlaceShip(model, location);  // Debugging - 07.Copy this from commented code above 05.
				}                                                           //  Debugging - 08. Surround with tru catch snippet
				catch (Exception ex)   // Debugging - 09. Add 'ex' to Exception
				{
					//throw;
					Console.WriteLine("Error: " + ex.Message);   // Debugging - 10. Add print out 'ex' message with string interpolation.
				} 


				if (isValidLocation == false) 
				{
					Console.WriteLine("That was not a valid location. Please try again. "); 
				}
			} while (model.ShipLocations.Count < 5);
		}
	}
}
