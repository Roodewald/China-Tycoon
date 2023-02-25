using UnityEngine;

namespace ToasterGames
{
	[System.Serializable]
	public class PlayerProfileData : MonoBehaviour
	{

		public int curretMoney;
		public int curretDiamonds;
		public bool showAD;
	
		public PlayerProfileData()
		{
			curretMoney = 100;
			curretDiamonds = 10;
			showAD = true;
		}
	}
}

