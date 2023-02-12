using UnityEngine;

namespace ToasterGames
{
	public class CameraInteract : MonoBehaviour
	{
		private void Update()
		{
			if (Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);

				if (touch.phase == TouchPhase.Began)
				{
					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay(touch.position);

					if (Physics.Raycast(ray, out hit))
					{
						if (hit.transform.GetComponent<IInteractable>() != null)
						{
							hit.transform.GetComponent<IInteractable>().Interact();
						}
						else
						{
							UIManager.instance.Interact(false);
						}
					}
				}
			}
		}
	}
}