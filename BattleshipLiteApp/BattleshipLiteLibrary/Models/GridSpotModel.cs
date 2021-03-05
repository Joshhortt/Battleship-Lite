using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
	public class GridSpotModel  // 2. add public
	{
		// 3. add properties 
		public string SpotLetter { get; set; }
		public int SpotNumber { get; set; }
		public int Status { get; set; }  // 0 = empty, 1 = ship, 2 = miss, 3 = hit, 4 = sunk
	}
}
