//II - Add new project Console Aplication

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
			WelcomeMessage();    // 3. calling the Welcome Message from the Method
			Console.ReadLine(); //  1. add this right after creating new project.
		}

		private static void WelcomeMessage()  // 2.Method WelcomeMessager
		{
			// Hit F5 - Message print out to screen
			Console.WriteLine("Welcome to Battleship Lite");
			Console.WriteLine("Created by Josh Hortt");
			Console.WriteLine();
		}
		private static PlayerInfoModel CreatePlayer()  // 4. Add anothet method. Add also reference BattleshipLiteLibrary, 
			                                                //and add using BattleshipLiteLibrary.Models on top;
		{
			PlayerInfoModel ouput = new PlayerInfoModel();  // 5. add new Instance

			// Ask the user for their name
			ouput.UserName = AskForUsersName();

			// Load up the shot grid
			

			// Ask the user for their 5 ship placements
			// Clear
		}
		private static string AskForUsersName()  // 6. Add another string method. Asking users name and scope
		{
			Console.Write("What is your name: ");
			string output = Console.ReadLine();

			return output;
		}
	}
}
