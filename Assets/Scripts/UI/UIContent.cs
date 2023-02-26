using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ToasterGames
{
	public class UIContent : MonoBehaviour
	{
		public Content contentPrefab;
		public Transform contentTransform;
		private List<Content> contentCreatedPrefab = new List<Content>();
		[SerializeField] private TMP_Text upgradableName;
		[SerializeField] private TMP_Text roomName;
		[SerializeField] private TMP_Text upgradableDiscription;
		[SerializeField] private TMP_Text upgradableLevel;
		[SerializeField] private Image upgradableIcon;
		[SerializeField] private Button upgrateButton;
		[SerializeField] private TMP_Text upgratePrice;
		[SerializeField] private Wallet wallet;

		private Upgradable selectedUpgradable;

		public void CreateContentButton(Upgradable[] upgradables, string _roomName)
		{
			if (upgradables != null)
			{
				foreach (Upgradable upgradable in upgradables)
				{
					Content createdPrefab = Instantiate(contentPrefab, contentTransform);
					createdPrefab.upgradable = upgradable;
					contentCreatedPrefab.Add(createdPrefab);
				}
				contentCreatedPrefab[0].button.Select();
				contentCreatedPrefab[0].OnClick();
			}
			roomName.text = _roomName;
		}

		public void UpdateName(Upgradable upgradable)
		{
			selectedUpgradable = upgradable;
			upgradableName.text = selectedUpgradable.upgradableName;
			upgradableDiscription.text = selectedUpgradable.discription;
			upgradableLevel.text = selectedUpgradable.level.ToString();
			upgradableIcon.sprite = selectedUpgradable.icon;
			upgratePrice.text = selectedUpgradable.price.ToString();

			if (wallet.CanBuyMoneyUprgate(selectedUpgradable.price))
			{
				upgratePrice.color = Color.green;
				upgrateButton.interactable = true;
			}
			else
			{
				upgratePrice.color = Color.red;
				upgrateButton.interactable = false;
			}
		}

		public void DeliteUpgratables()
		{
			if (contentCreatedPrefab != null)
			{
				foreach (Content content in contentCreatedPrefab)
				{
					Destroy(content.gameObject);
				}
				contentCreatedPrefab.Clear();
			}
		}
		public void Upgrate()
		{
			wallet.ChangeMoney(-selectedUpgradable.price);
			selectedUpgradable.Upgrate();
			UpdateName(selectedUpgradable);
		}
	}
}