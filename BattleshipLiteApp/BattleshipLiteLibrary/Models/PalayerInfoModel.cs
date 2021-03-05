using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLiteLibrary.Models
{
	public class PalayerInfoModel // 1. add public
	{
		// 4. properties
		public string UserName { get; set; }
		public List<GridSpotModel> ShipLocation { get; set; }
		public List<GridSpotModel> ShotGrid { get; set; }
	}
}
