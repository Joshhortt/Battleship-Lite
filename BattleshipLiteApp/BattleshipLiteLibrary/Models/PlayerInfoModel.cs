// I - Class Library
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
	public class PlayerInfoModel // 1. add public
	{
		// 4. properties
		public string UserName { get; set; }
		public List<GridSpotModel> ShipLocations { get; set; } = new List<GridSpotModel>();      // 33. add new List Instance
		public List<GridSpotModel> ShotGrid { get; set; } = new List<GridSpotModel>();     // 34. add new List Instance
	}
}
