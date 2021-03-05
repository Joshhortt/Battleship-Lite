//II - Add new project Console Aplication
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
	}
}
