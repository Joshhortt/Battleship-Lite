// IV -Wire up the logic - Implement logic here
using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary
{
	public class GameLogic  
	{
		public static void InitializeGrid(PlayerInfoModel model)  
		{
			List<string> letters = new List<string>  
			{
				"A",
				"B",
				"C",
				"D",
				"E"
			};

			List<int> numbers = new List<int>  
			{
				1,
				2,
				3,
				4,
				5
			};

			foreach (string letter in letters)  
			{
				foreach (int number in numbers)  
				{
					AddGridSpot(model, letter, number);
				}
			} 
		}

		private static void AddGridSpot(PlayerInfoModel model, string letter, int number)
		{
			GridSpotModel spot = new GridSpotModel 
			{
				SpotLetter = letter,
				SpotNumber = number,
				Status = GridSpotStatus.Empty
			};

			model.ShotGrid.Add(spot);  
		}

		public static bool PlaceShip(PlayerInfoModel model, string location) 
		{
			// 0. throw new NotImplementedException();

			bool output = false; // 11. add boolean = false

			(string row, int column) = SplitShotIntoRowAndColumn(location); // 1. Copy parameters of row and column from 'SplitShotIntoRowAndColumn' method.

			bool isValidLocation = ValidateGridLocation(model, row, column);   // 6. Validation is going to determine if it on the grid. 
																			   // Created from here a method below.

			bool isSpotOpen = ValidateShipLocation(model, row, column);   // 8. Validation is going to determine if it on right grid spot or not. 
																		  // Looking at ships that already been placed. Is there already a ship here?
																		  // Created from here a method below.

			if (isValidLocation && isSpotOpen)  // 10. surround (2.,3.,4., and 5.) with if snippet
			{
				model.ShipLocations.Add(new GridSpotModel  // 2. 
				{
					SpotLetter = row.ToUpper(),  // 3.  add ToUpper
					SpotNumber = column,  // 4. 
					Status = GridSpotStatus.Ship  // 5. there's a ship here that is not sunk
				});
				output = true; // 12. bool output (true - place ship)
			}
			return output;  // 13. return statement (false -  do nothing)
		}

		private static bool ValidateShipLocation(PlayerInfoModel model, string row, int column)  // method created 'PlaceShip 'from 8..
		{
			// 0. throw new NotImplementedException();
			bool isValidLocation = false;  // 1. add boolean = false;

			foreach (var ship in model.ShipLocations)  // 2. loop though every ship in ship locations.
			{
				if (ship.SpotLetter == row.ToUpper() && ship.SpotNumber == column)   // 4. Comparing Uppercase to Uppercase 
				{
					isValidLocation = false; // 5. If row and column match, then it's a invalid location, beacuse there's already a ship here.
				}
			}
			return isValidLocation;  // 6. return statement.
		}

	}

		private static bool ValidateGridLocation(PlayerInfoModel model, string row, int column)  // method created 'PlaceShip'from 6.
		{
			throw new NotImplementedException();
		}

		public static bool PlayerStillActive(PlayerInfoModel player)   // 1. change parameter 'opponentPlayer' in this method to just 'player', 
		{														      //  it won´t affect functionality, it's just the renaming for this particular method.
			// 0. throw new NotImplementedException();
			bool isActive = false; // 2. If player is NOT active, means does not have any ship.

			foreach (var ship in player.ShipLocations )  // 3. For each ship in ship locations.
			{
				if (ship.Status != GridSpotStatus.Sunk)   // 4. If it is NOT sunk.
				{
					isActive = true; // 5. Then the player is still active at least with one ship.
				}
			}
			return isActive;  // 6. return statement.
		}

		public static int GetShotCount(PlayerInfoModel player)   // 1. change parameter 'winner' in this method to just 'player', 
		{                                                        //  it won´t affect functionality, it's just the renaming for this particular method.
																 // 0. throw new NotImplementedException();
			int shotCount = 0;  // 2. starting point shot count will be zero.

			foreach (var shot in player.ShotGrid)  // 3. for each shot player in shot grid
			{
				if (shot.Status != GridSpotStatus.Empty)   // 4. they either have taken a shot or missed. 
				{
					shotCount += 1; // 5. Adds one to our shot count
				}
			}
			return shotCount;  // 6. return statement.

		}

		public static (string row, int column) SplitShotIntoRowAndColumn(string shot)  
		{
		throw new NotImplementedException();
		
		}

		public static bool ValidateShot(PlayerInfoModel activePlayer, string row, int column) 
		{
			throw new NotImplementedException();
		}

		public static bool IdentifyShowResult(PlayerInfoModel opponentPlayer, string row, int column)  
		{
			throw new NotImplementedException();
		}

		public static void MarkShotResult(PlayerInfoModel activePlayer, string row, int column, bool isAHit) 
		{
			throw new NotImplementedException();
		}
	}
}


