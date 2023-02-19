using UnityEngine;
using UnityEngine.UI;

namespace ToasterGames
{
	public class Content : MonoBehaviour
	{
		public Upgradable upgradable;
		[SerializeField] private Image icon;
		public Button button;

		private void Start()
		{
			icon.sprite = upgradable.icon;
		}

	
		public void OnClick()
		{
			UIManager.Instance.uIContent.UpdateName(upgradable);
		}
	}
}
