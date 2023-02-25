using UnityEngine;

namespace ToasterGames
{
	public class PlayerProfile : MonoBehaviour
	{
		public static PlayerProfile Instance;

		[SerializeField] UIManager uIManager;
		private int curretMoney;
		private int curretDiamonds;
		private bool showAD;
	

		private const string saveKey = "mainSave";


		private void Awake()
		{
			Instance= this;
			Load();
		}

		private void Load()
		{
			var data = SaveManager.Load<PlayerProfileData>(saveKey);
			curretMoney = data.curretMoney;
			curretDiamonds = data.curretDiamonds;
			showAD = data.showAD;
			UpdateUI();

		}
		private void Save()
		{
			SaveManager.Save(saveKey, GetSaveSnapshot());
			UpdateUI();
		}

		private PlayerProfileData GetSaveSnapshot()
		{
			var data = new PlayerProfileData()
			{
				curretMoney = curretMoney,
				curretDiamonds = curretDiamonds,
				showAD = showAD,
			};
			return data;
		}
		private void UpdateUI()
		{
			var uIMoneyPanel = uIManager.uIMoneyPanel;
			uIMoneyPanel.money.text = curretMoney.ToString();
			uIMoneyPanel.diamonds.text= curretDiamonds.ToString();
		}
	}
}