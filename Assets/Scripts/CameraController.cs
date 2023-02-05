using UnityEngine;

namespace ToasterGames
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private float movementTime;
		[SerializeField] private Camera cameraOnRig;

		private Vector3 movingPosition;
		private bool drag = false;
		private Vector3 origin;
		private Vector3 diffrence;


		private void FixedUpdate()
		{
			if (Input.touchCount == 1)
			{
				//Get first touch
				Touch touch = Input.GetTouch(0);

				if (!drag)
				{
					drag = true;
					origin = cameraOnRig.ScreenToViewportPoint(touch.position);
				}

				diffrence = origin - cameraOnRig.ScreenToViewportPoint(touch.position);

				movingPosition.x = diffrence.x + transform.position.x;
				movingPosition.z = diffrence.y + transform.position.z;
				movingPosition.y = transform.position.y;

				//Apply move
				transform.position = Vector3.Lerp(transform.position, movingPosition, Time.deltaTime * movementTime);

			}
			else
			{
				drag = false;
			}
		}
	}
}
