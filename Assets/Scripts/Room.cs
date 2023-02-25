using UnityEngine;

namespace ToasterGames
{
	public class Room : MonoBehaviour, IInteractable
	{
		public string roomName;
		public Bench[] benchs;

		private UIManager uIManager;

		private void Start()
		{
			uIManager = UIManager.Instance;
		}

		public void Interact()
		{
			uIManager.SetActivePanel(1);

			uIManager.uIContent.CreateContentButton(benchs,roomName);

			CameraController.instance.SetShowingObject(gameObject);
		}
	}

}
