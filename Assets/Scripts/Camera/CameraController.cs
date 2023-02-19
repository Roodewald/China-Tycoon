using UnityEngine;

namespace ToasterGames
{

	public class CameraController : MonoBehaviour
	{
		public static CameraController instance;

		private CameraMover cameraMover;
		private CameraZoom cameraZoom;
		[SerializeField] private float distanceToShowingObject = 7f;

		private void Awake()
		{
			instance = this;
			cameraZoom = GetComponent<CameraZoom>();
			cameraMover = GetComponent<CameraMover>();
		}


		public void SetFolowingObject(GameObject _folowingObject)
		{
			cameraMover.folowingObject = _folowingObject;
		}

		public void SetShowingObject(GameObject _showingObject)
		{

			cameraMover.showingObject = _showingObject;
			Vector3 targetPostition = _showingObject.transform.position;
			cameraZoom.SetZoom(40f);
			cameraMover.targetPosition = new Vector3(targetPostition.x, targetPostition.y, targetPostition.z - distanceToShowingObject);

		}

		public void ResetCamera()
		{
			cameraMover.folowingObject = null;
			cameraMover.showingObject = null;
			cameraZoom.SetZoom(60f);
			UIManager.Instance.SetActivePanel(0);
		}
	}
}
