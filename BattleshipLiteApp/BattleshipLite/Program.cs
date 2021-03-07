﻿// III - Console App Creation part2
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

		private static void IdentifyWinner(PlayerInfoModel winner)  // 22. Method created
		{
			//throw new NotImplementedException();
			Console.WriteLine($"Congratulations to {winner.UserName} for winning!");  // 23. Add message congratulating userName for winning
			Console.WriteLine($"{ winner.UserName } took { GameLogic.GetShotCount(winner) } shots.");  // 24. Add another message right after tellig 
			                                                                                           // the user that he took blank shots
																								       // Create also 'GetShotCount' method in GameLogic.cs
		}

		private static void RecordPlayerShot(PlayerInfoModel activePlayer, PlayerInfoModel opponentPlayer)
		{
			// 15. Delete throw new NotImplementedException();

			// 26. Add do while loop'
			bool isValidShot = false;  
			string row = "";          // 39.a declare row type
			int column = 0;           // 39.b declare column type

			do
			{
				// Asks for a shot (we ask for 'B2')
				string shot = AskForShot();  // 27. Add variable and calling Method & Created method 'AskForShot' from here

				// Determine what row and columnms that is  - split it apart
				(row, column) = GameLogic.SplitShotIntoRowAndColumn(shot);  // 33. Add 'Tuple' and method that will be created in 'GameLogic'
																		    //39.c removed types
				// Determine if that is a valid result	
				isValidShot = GameLogic.ValidateShot(activePlayer, row, column);  // 35. Add if validation is valid and create Method from here into 'GameLogic'

				// Show a warning message
				if (isValidShot == false)  // 37. Add if the validation is false the show a message
				{
					Console.WriteLine("Invalid Shot Location. Please try again! ");  // 38. show a message
				}

				// Go back to the beginning if not a valid shot
			} while (isValidShot == false);  // or (!isValidShot) -- If it's false the loop start's all over from the beginning.

			// Determine shot results
			bool isAHit = GameLogic.IdentifyShowResult(opponentPlayer, row, column);  // 39. Add if it is a hit identify shot results. create Method from here in 'GameLogic'

			// Record results 
			GameLogic.MarkShotResult(activePlayer, row, column, isAHit);  // 41. Add record results. create Method from here in 'GameLogic'
		}

		private static string AskForShot()  // 28. Method creted above from 27.' do while loop 
		{
			//throw new NotImplementedException(); 29. comment or delete

			Console.Write("Please enter your shot selection: ");  // 30. Add message
			string output = Console.ReadLine();  // 31. Add capture what the user types in and return it

			return output;  // 32. Add return output
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
