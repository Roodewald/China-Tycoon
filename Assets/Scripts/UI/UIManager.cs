using UnityEngine;

namespace ToasterGames
{
	public class UIManager : MonoBehaviour
	{
		public static UIManager Instance;
		public UIContent uIContent;

		[SerializeField] private GameObject[] panels;


		private void Awake()
		{
			Instance = this;
			SetActivePanel(0);
		}

		public void SetActivePanel(int targetPanel)
		{
			foreach (GameObject panel in panels)
			{
				panel.SetActive(false);
			}
			uIContent.DeliteUpgratables();
			panels[targetPanel].SetActive(true);
		}

	}
}
