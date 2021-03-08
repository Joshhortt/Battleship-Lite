//Final Application
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
			string row = "";
			int column = 0;

			bool isValidShot;
			do
			{
				string shot = AskForShot(activePlayer);

				try
				{
					(row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);
					isValidShot = GameLogic.ValidateShot(activePlayer, row, column);
				}
				catch (Exception)
				{

					isValidShot = false;
				}

				if (isValidShot == false)
				{
					Console.WriteLine("Invalid Shot Location. Please try again! ");
				}
			} while (isValidShot == false);

			bool isAHit = GameLogic.IdentifyShotResult(opponentPlayer, row, column);
		
			GameLogic.MarkShotResult(activePlayer, row, column, isAHit);
			DisplayShotResult(row, column, isAHit);   										 
		}

		private static void DisplayShotResult(string row, int column, bool isAHit)   
		{
			if(isAHit) 
			{
				Console.WriteLine($"{ row } { column } is a Hit!"); 
			}
			else
			{
				Console.WriteLine($"{ row } { column } is a Miss!"); 
			}
			Console.WriteLine(); 
		}

		private static string AskForShot(PlayerInfoModel player)  
		{
			Console.Write($"{player.UserName }, Please enter your shot selection: ");  
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
					Console.Write(" X  ");  
				}
				else if(gridSpot.Status == GridSpotStatus.Miss) 
				{
					Console.Write(" O  ");  
				}
				else
					Console.Write(" ?  ");  
			}
			Console.WriteLine();  
			Console.WriteLine();  
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

				bool isValidLocation = false;  

				try
				{
					isValidLocation = GameLogic.PlaceShip(model, location);  
				}                                                          
				catch (Exception ex)   
				{
					Console.WriteLine("Error: " + ex.Message);   
				} 

				if (isValidLocation == false) 
				{
					Console.WriteLine("That was not a valid location. Please try again. "); 
				}
			} while (model.ShipLocations.Count < 5);
		}
	}
}
