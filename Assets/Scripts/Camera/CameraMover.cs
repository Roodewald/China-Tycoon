using UnityEngine;
using UnityEngine.EventSystems;

namespace ToasterGames
{
	public class CameraMover : MonoBehaviour
	{
		public float speed = 10f;
		public float smoothing = 5f;

		public float limitX = 10;
		public float limitZ = 10;

		public Vector3 targetPosition;

		public GameObject folowingObject = null;
		public GameObject showingObject = null;


		private Vector3 velocity = Vector3.zero;
		private Vector3 swipe;


		[SerializeField] private CameraZoom cameraZoom;

		private void Awake()
		{
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
					swipe = new Vector3(touch.deltaPosition.x, touch.deltaPosition.y, 0) * speed * Time.deltaTime;
					targetPosition = new Vector3(transform.position.x - swipe.x, transform.position.y, transform.position.z - swipe.y);

					targetPosition.x = Mathf.Clamp(targetPosition.x, -limitX, limitX);
					targetPosition.z = Mathf.Clamp(targetPosition.z, -limitZ, limitZ);
				}
			}
		}
		private void FollowTheObject() => targetPosition = folowingObject.transform.position;

	}
}
