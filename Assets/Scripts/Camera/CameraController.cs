using UnityEngine;

namespace ToasterGames
{
	public class CameraController : MonoBehaviour
	{
		public float speed = 10f;
		public float smoothing = 5f;

		public float limitX = 10;
		public float limitZ = 10;

		private Vector3 targetPosition;
		private Vector3 velocity = Vector3.zero;

		private void LateUpdate()
		{
			MooveCamera();
		}

		private void MooveCamera()
		{
			if (Input.touchCount == 1)
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

			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothing * Time.deltaTime);
		}
	}
}
