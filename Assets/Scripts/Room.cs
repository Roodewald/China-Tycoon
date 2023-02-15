using UnityEngine;

namespace ToasterGames
{
	public class Room : MonoBehaviour, IInteractable
	{
		public string roomName;

		public GameObject[] benchs;

		public void Interact()
		{
			UIManager.Instance.SetActivePanel(1);
			CameraController.instance.SetShowingObject(gameObject);
		}
	}

}
