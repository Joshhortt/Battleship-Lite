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
			foreach(string item in letters)  // 12. loop through to every single letter
			{
				foreach (int number in numbers)  // 13. Inside each letter we re going to loop through to every single number
				{ 
				}
			}
		}
		private static void AddGridSpot(PlayerInfoModel model, string letter, string number) // 14. add new method
		{
			                                                                                     
		}
	}
}
