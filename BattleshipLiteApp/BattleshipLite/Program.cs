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

			PlayerInfoModel activePlayer = CreatePlayer("Player 1"); 
			PlayerInfoModel opponentPlayer = CreatePlayer("Player 2"); 
			PlayerInfoModel winner = null;  

			do 
			{
				// Display grid from activePlayer on where they fired
				DisplayShotGrid(activePlayer); 
			                                    
				// Ask activePlayer for a shot
				// Determine if it is a valid shot
				// Determine shot results
				RecordPlayerShot(activePlayer, opponentPlayer);   
				
				// Determine if the game is over
				bool doesGameContinue = GameLogic.PlayerStillActive(opponentPlayer);  
																					 
				// If over set activePlayer as the winner
				if (doesGameContinue == true)  
				{
				// swap positions (activePlayer to opponentPlayer)
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
