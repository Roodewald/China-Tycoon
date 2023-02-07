using UnityEngine;

namespace ToasterGames
{
	public class CameraInteract : MonoBehaviour
	{
		private void Update()
		{
			if (Input.touchCount == 1)
			{
				if (Input.GetTouch(0).phase == TouchPhase.Stationary)
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

					if (Physics.Raycast(ray, out hit))
					{
						if (hit.transform.GetComponent<IInteractable>() != null)
						{
							hit.transform.GetComponent<IInteractable>().Interact();
						}
					}
				}
			}
		}
	}
}
