using UnityEngine;

namespace ToasterGames
{
	public class CameraZoom : MonoBehaviour
	{
		public float zoomMax;
		public float zoomMin;
		public float sensitivity;
		public float curretZoom = 60;

		[SerializeField] private float zoomChangeDuration = 0.2f;
		[SerializeField] private Camera cameraRig;

		private Touch touchA;
		private Touch touchB;
		private Vector2 touchADirection;
		private Vector2 touchBDirection;
		private float distanceBtwTouchesPosition;
		private float distanceBtwTouchesDirections;
		private float zoom;
		private float curretTime;
		private bool zoomChanging = false;
		private float targetZoom;



		private void Update()
		{
			if (Input.touchCount == 2)
			{
				touchA = Input.GetTouch(0);
				touchB = Input.GetTouch(1);

				touchADirection = touchA.position - touchA.deltaPosition;
				touchBDirection = touchB.position - touchB.deltaPosition;

				distanceBtwTouchesPosition = Vector2.Distance(touchA.position, touchB.position);
				distanceBtwTouchesDirections = Vector2.Distance(touchADirection, touchBDirection);

				zoom = distanceBtwTouchesPosition - distanceBtwTouchesDirections;

				curretZoom = cameraRig.fieldOfView - zoom * sensitivity;
				cameraRig.fieldOfView = Mathf.Clamp(curretZoom, zoomMin, zoomMax);
			}
			if (zoomChanging)
			{
				ChangeZoom();
			}

		}


		public void SetZoom(float _targetZoom)
		{
			zoomChanging = true;
			targetZoom = _targetZoom;
		}

		private void ChangeZoom()
		{
			curretTime += Time.deltaTime;
			cameraRig.fieldOfView = Mathf.Lerp(curretZoom, targetZoom, curretTime / zoomChangeDuration);
			curretZoom = cameraRig.fieldOfView;
			if (curretTime >= zoomChangeDuration)
			{
				zoomChanging = false;
				curretTime = 0;
			}
		}

		public float GetCuretZoom() => curretZoom;
	}
}
