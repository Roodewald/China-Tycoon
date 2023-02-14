using UnityEngine;
using UnityEngine.EventSystems;

namespace ToasterGames
{
	public class CameraController : MonoBehaviour
	{
		public static CameraController Instance;

		public float speed = 10f;
		public float smoothing = 5f;

		public float limitX = 10;
		public float limitZ = 10;

		private Vector3 targetPosition;


		private Vector3 velocity = Vector3.zero;

		private GameObject folowingObject = null;
		private GameObject showingObject = null;

		[SerializeField] private CameraZoom cameraZoom;

		private void Awake()
		{
			Instance = this;
			targetPosition = transform.position;
		}


		private void LateUpdate()
		{
			if (!folowingObject && !showingObject)
				MoveCamera();
			else if (folowingObject)
				FollowTheObject();

			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing * Time.deltaTime);
		}

		private void MoveCamera()
		{
			if (Input.touchCount == 1 && !EventSystem.current.IsPointerOverGameObject(0))
			{
				Touch touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Moved)
				{
					Vector3 swipe = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0) * speed * Time.deltaTime;
					targetPosition = new Vector3(transform.position.x - swipe.x, transform.position.y, transform.position.z - swipe.y);

					targetPosition.x = Mathf.Clamp(targetPosition.x, -limitX, limitX);
					targetPosition.z = Mathf.Clamp(targetPosition.z, -limitZ, limitZ);
				}
			}
		}
		private void FollowTheObject() => targetPosition = folowingObject.transform.position;


		public void SetFolowingObject(GameObject _folowingObject)
		{

			folowingObject = _folowingObject;
		}

		public void SetShowingObject(GameObject _showingObject)
		{

			showingObject = _showingObject;
			cameraZoom.SetZoom(40f);
			targetPosition = _showingObject.transform.position;
		}

		public void ResetCamera()
		{
			folowingObject = null;
			showingObject = null;
			cameraZoom.SetZoom(60);
		}


	}
}
