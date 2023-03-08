using UnityEngine;

namespace ToasterGames
{
	public class Stock : MonoBehaviour, IInteractable
	{
		private UIManager uIManager;

		private void Start()
		{
			uIManager = UIManager.Instance;
		}

		public void Interact()
		{
			uIManager.SetActivePanel(1);

			

			CameraController.instance.SetShowingObject(gameObject);
		}
	}
}