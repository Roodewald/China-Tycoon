using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToasterGames
{
	public class CameraZoom : MonoBehaviour
	{
		public float zoomMax;
		public float zoomMin;
		public float sensitivity;

		[SerializeField]private Camera cameraRig;

		private Touch touchA;
		private Touch touchB;
		private Vector2 touchADirection;
		private Vector2 touchBDirection;
		private float distanceBtwTouchesPosition;
		private float distanceBtwTouchesDirections;
		private float zoom;

		private void Update()
		{
			if (Input.touchCount == 2)
			{
				touchA = Input.GetTouch(0);
				touchB = Input.GetTouch(1);

				touchADirection = touchA.position - touchA.deltaPosition;
				touchBDirection = touchB.position - touchB.deltaPosition;

				distanceBtwTouchesPosition = Vector2.Distance(touchA.position, touchB.position);
				distanceBtwTouchesDirections = Vector2.Distance(touchADirection,touchBDirection);

				zoom = distanceBtwTouchesPosition - distanceBtwTouchesDirections;

				var curretZoom = cameraRig.fieldOfView - zoom * sensitivity;

				cameraRig.fieldOfView = Mathf.Clamp(curretZoom, zoomMin, zoomMax);

			}
		}
	}
}
