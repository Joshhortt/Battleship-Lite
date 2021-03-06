//II - (cont.) after adding new project Console Aplication
using BattleshipLiteLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary
{
	public class GameLogic  // 7. add public
	{
		public static void InitializeGrid(PlayerInfoModel model)  // 8. add new method
		{
			List<string> letters = new List<string>  // 9. add ne List of letters
			{
				"A",
				"B",
				"C",
				"D",
				"E"
			};

			List<int> numbers = new List<int>  // 10. add ne List of numbers
			{
				1,
				2,
				3,
				4,
				5
			};

			// 11. Adding Grid Items
			foreach (string letter in letters)  // 12. loop through to every single letter
			{
				foreach (int number in numbers)  // 13. Inside each letter we re going to loop through to every single number
				{
					AddGridSpot(model, letter, number); //17. calling AddGridSpot
				}
			} 
		}

		private static void AddGridSpot(PlayerInfoModel model, string letter, int number) // 14. add new method
		{
			GridSpotModel spot = new GridSpotModel  // 15. new Instance Spot initialized
			{
				SpotLetter = letter,
				SpotNumber = number,
				Status = GridSpotStatus.Empty
			};

			model.ShotGrid.Add(spot);  // 16.
		}

		public static bool PlaceShip(PlayerInfoModel model, string location)
		{
			throw new NotImplementedException();
		}
	}
}


