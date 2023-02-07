using UnityEngine;

namespace ToasterGames
{
	public class PlaceToCreate : MonoBehaviour, IInteractable
	{
		private void Update()
		{
			if (Input.touchCount == 3)
			{
				InternalAds.instance.ShowAd();
			}
		}
	}

}
