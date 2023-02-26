using UnityEngine;

namespace ToasterGames
{
	public class Wallet : MonoBehaviour
	{
		public static Wallet Instance;

		private int curretMoney;
		private int curretDiamonds;
		private int curretEnergy;
		private bool showAD;

		private void Awake()
		{
			Instance = this;
		}

		public int GetCurretMoney() => curretMoney;
		public void SetCureentMoney(int setMoney) => curretMoney = setMoney;
		public bool CanBuyMoneyUprgate(int price) => curretMoney >= price;
		public void ChangeMoney(int addedMoney) {
			curretMoney += addedMoney;
			PlayerProfile.Instance.Save();
		}

		public int GetCurretDiamonds() => curretDiamonds;
		public void SetCurretDiamonds(int setDiamonds) => curretDiamonds = setDiamonds;
		public void ChangeDiamonds(int addedDiamonds)
		{
			curretDiamonds += addedDiamonds;
			PlayerProfile.Instance.Save();
		}

		public int GetEnergy() => curretEnergy;
		public void SetEnergy(int setEnergy) => curretEnergy = setEnergy;
		public void ChangeEnergy(int addedEnergy) => curretEnergy += addedEnergy;

		public bool GetShowingAD() => showAD;
		public void SetShowAD(bool _showAD) => showAD = _showAD;
	}
}