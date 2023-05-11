using System;
using System.Globalization;
using UnityEngine;

// ReSharper disable once CheckNamespace
namespace ToasterGames
{
    public class PlayerProfile : MonoBehaviour
    {
        public static PlayerProfile instance;

        [SerializeField] private UIManager uIManager;
        [SerializeField] private Wallet wallet;
        [SerializeField] private Stock stock;
        private DateTime dateTime;
        public double secondsPassed;
        

        private const string SAVE_KEY = "mainSave15";

        private void Awake()
        {
            instance = this;
            Load();
        }

        private void Load()
        {
            var data = SaveManager.Load<PlayerProfileData>(SAVE_KEY);
            wallet.SetCurrentMoney(data.currentMoney);
            wallet.SetCurrentDiamonds(data.currentDiamonds);
            wallet.SetShowAD(data.showAD);
            stock.storage = data.storage;
            if (!DateTime.TryParseExact(data.dateTime, "u", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTime))
            {
                Debug.Log($"DateTime can be empty, try load default Value!");
                dateTime = DateTime.UtcNow;
                
            }
            TimeSpan timePassed = DateTime.UtcNow - dateTime;
            secondsPassed = timePassed.TotalSeconds;
            Debug.Log(secondsPassed);
            
            UpdateUI();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            Save();
        }

        public void Save()
        {
            SaveManager.Save(SAVE_KEY, GetSaveSnapshot());
            UpdateUI();
        }

        private PlayerProfileData GetSaveSnapshot()
        {
            var data = new PlayerProfileData()
            {
                currentMoney = wallet.GetCurrentMoney(),
                currentDiamonds = wallet.GetCurrentDiamonds(),
                showAD = wallet.GetShowingAD(),
                storage = stock.storage,
                dateTime = DateTime.UtcNow.ToString("u", CultureInfo.InvariantCulture),
            };
            return data;
        }

        private void UpdateUI()
        {
            var uIMoneyPanel = uIManager.uIMoneyPanel;
            uIMoneyPanel.AddMoney(wallet.GetCurrentMoney());
            uIMoneyPanel.AddDiamonds(wallet.GetCurrentDiamonds());
        }
    }
}