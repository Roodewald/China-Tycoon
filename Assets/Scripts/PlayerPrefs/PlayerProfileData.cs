using System;
using UnityEngine;

namespace ToasterGames
{
	[System.Serializable]
	public class PlayerProfileData
	{

		public int currentMoney;
		public int currentDiamonds;
		public bool showAD;
		public int[] storage = new int[10];
		public string dateTime;
		
	
		public PlayerProfileData()
		{
			currentMoney = 100;
			currentDiamonds = 10;
			showAD = true;
		}
	}
}

