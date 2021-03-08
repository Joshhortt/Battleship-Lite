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


