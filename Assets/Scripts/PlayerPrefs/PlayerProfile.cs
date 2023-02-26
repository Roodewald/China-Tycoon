using UnityEngine;

namespace ToasterGames
{
	public class PlayerProfile : MonoBehaviour
	{
		public static PlayerProfile Instance;

		[SerializeField] UIManager uIManager;
		[SerializeField] Wallet wallet;
	

		private const string saveKey = "mainSave";


		private void Awake()
		{
			Instance= this;
			Load();
		}

		private void Load()
		{
			var data = SaveManager.Load<PlayerProfileData>(saveKey);
			wallet.SetCureentMoney(data.currentMoney);
			wallet.SetCurretDiamonds(data.currentDiamonds);
			wallet.SetShowAD(data.showAD);
			UpdateUI();

		}
		public void Save()
		{
			SaveManager.Save(saveKey, GetSaveSnapshot());
			UpdateUI();
		}

		private PlayerProfileData GetSaveSnapshot()
		{
			var data = new PlayerProfileData()
			{
				currentMoney = wallet.GetCurretMoney(),
				currentDiamonds = wallet.GetCurretDiamonds(),
				showAD = wallet.GetShowingAD()
			};
			return data;
		}
		private void UpdateUI()
		{
			var uIMoneyPanel = uIManager.uIMoneyPanel;
			uIMoneyPanel.money.text = wallet.GetCurretMoney().ToString();
			uIMoneyPanel.diamonds.text= wallet.GetCurretDiamonds().ToString();
		}
	}
}