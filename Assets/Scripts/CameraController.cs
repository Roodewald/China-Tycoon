using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float movementTime;
    [SerializeField] private Camera cameraOnRig;

	Vector3 movingPosition;

	bool drag = false;
	Vector3 origin;

	Vector3 diffrence;


	private void Update()
	{
		if (Input.touchCount == 1)
		{
			Touch touch = Input.GetTouch(0);

			//Debug.Log(cameraOnRig.ScreenToViewportPoint(touch.position));
			if (!drag)
			{
				drag = true;
				origin = cameraOnRig.ScreenToViewportPoint(touch.position);
			}

			diffrence = origin - cameraOnRig.ScreenToViewportPoint(touch.position);
			Debug.Log(diffrence);
			movingPosition.x = diffrence.x + transform.position.x;
			movingPosition.z = diffrence.y + transform.position.z;
			movingPosition.y = transform.position.y;


			transform.position = Vector3.Lerp(transform.position, movingPosition, Time.deltaTime * movementTime);

		}
		else
		{
			drag = false;
		}
	}



}
