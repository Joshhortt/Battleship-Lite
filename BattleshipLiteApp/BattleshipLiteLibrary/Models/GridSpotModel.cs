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

		// 7. overwrite 'int' and put 'GridSpotStatus'
		public GridSpotStatus Status { get; set; } = GridSpotStatus.Empty; // 8. And add '.empty' to 'GridSpotStatus' by default.
	}
}
