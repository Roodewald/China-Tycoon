using UnityEngine;

namespace ToasterGames
{
	public abstract class Upgradable : MonoBehaviour
	{
		public string upgradableName;
		public string discription;
		public int price;

		public int level;

		public Sprite icon;

		public void Upgrate()
		{
			level++;
		}
	}

}
