using UnityEngine;

namespace ToasterGames
{
	public class PlaceToCreate : MonoBehaviour, IInteractable
	{
		private void Update()
		{
			if (Input.touchCount == 3)
			{
				CameraController.Instance.SetShowingObject(gameObject);
			}
			if (Input.touchCount == 4)
			{
				CameraController.Instance.ResetCamera();
			}
		}
	}

}
