using UnityEngine;

namespace ToasterGames
{
	public class UIManager : MonoBehaviour
	{
		public static UIManager Instance;

		[SerializeField] private GameObject[] panels;


		private void Awake()
		{
			Instance = this;
		}

		public void SetActivePanel(int targetPanel)
		{
			foreach (GameObject panel in panels)
			{
				panel.SetActive(false);
			}
			panels[targetPanel].SetActive(true);
		}

	}
}
