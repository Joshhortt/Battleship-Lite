// III - Console App Creation part2
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

		public static bool PlayerStillActive(PlayerInfoModel opponentPlayer)    // 16. Method created from program.cs
		{
			throw new NotImplementedException();
		}

		public static int GetShotCount(PlayerInfoModel winner)  // 25. Created method form IdentifyWinner method. Change 'object' to 'int'
		{
			throw new NotImplementedException();
		}

		public static (string row, int column) SplitShotIntoRowAndColumn(string shot)
		{
			throw new NotImplementedException();
		}
	}
}


