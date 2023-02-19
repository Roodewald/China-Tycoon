using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

namespace ToasterGames
{
	public class UIContent : MonoBehaviour
	{
		public Content contentPrefab;
		public Transform contentTransform;
		private List<Content> contentCreatedPrefab = new List<Content>();
		[SerializeField] private TMP_Text upgradableName;
		[SerializeField] private TMP_Text upgradableDiscription;
		[SerializeField] private TMP_Text upgradableLevel;
		[SerializeField] private Image upgradableIcon;

		public void CreateContentButton(Upgradable[] upgradables)
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
		}

		public void UpdateName(Upgradable upgradable)
		{
			upgradableName.text= upgradable.upgradableName;
			upgradableDiscription.text= upgradable.discription;
			upgradableLevel.text = upgradable.level.ToString();
			upgradableIcon.sprite= upgradable.icon;
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
	}

}
