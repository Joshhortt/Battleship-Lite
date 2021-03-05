﻿// I - Class Library
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
		public List<GridSpotModel> ShipLocations { get; set; }
		public List<GridSpotModel> ShotGrid { get; set; } // A1 - ... A5, B1 - ... B5 etc...
	}
}
