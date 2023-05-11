using UnityEngine;

namespace ToasterGames
{
	public class Wallet : MonoBehaviour
	{
		public static Wallet instance;

		private int currentMoney;
		private int currentDiamonds;
		private int currentEnergy;
		private bool showAD;

		private void Awake()
		{
			instance = this;
		}

		public int GetCurrentMoney() => currentMoney;
		public void SetCurrentMoney(int setMoney) => currentMoney = setMoney;
		public bool CanBuyMoneyUpgrade(int price) => currentMoney >= price;
		public void ChangeMoney(int addedMoney) {
			currentMoney += addedMoney;
			PlayerProfile.instance.Save();
		}

		public int GetCurrentDiamonds() => currentDiamonds;
		public void SetCurrentDiamonds(int setDiamonds) => currentDiamonds = setDiamonds;
		public void ChangeDiamonds(int addedDiamonds)
		{
			currentDiamonds += addedDiamonds;
			PlayerProfile.instance.Save();
		}

		public int GetEnergy() => currentEnergy;
		public void SetEnergy(int setEnergy) => currentEnergy = setEnergy;
		public void ChangeEnergy(int addedEnergy) => currentEnergy += addedEnergy;

		public bool GetShowingAD() => showAD;
		public void SetShowAD(bool _showAD) => showAD = _showAD;
	}
}