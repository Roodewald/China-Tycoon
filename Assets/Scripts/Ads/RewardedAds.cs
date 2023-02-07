using UnityEngine;
using UnityEngine.Advertisements;

namespace ToasterGames
{
	public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
	{
		public static RewardedAds instance;

		private static string andriodAdId = "Interstitial_Android";
		private static string iosAdeId = "Interstitial_iOS";

		private string adId;

		private void Awake()
		{
			instance = this;
			adId = (Application.platform == RuntimePlatform.Android) ? andriodAdId : iosAdeId;
		}

		public void LoadRAd()
		{
			Debug.Log("Loading Rewarded ad: " + adId);
			Advertisement.Load(adId, this);
		}
		public void ShowRAd()
		{
			Debug.Log("Showing Rewarded ad" + adId);
			Advertisement.Show(adId, this);
		}

		public void OnUnityAdsAdLoaded(string placementId)
		{
			Debug.Log("Ad loaded" + placementId);
		}

		public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
		{
			throw new System.NotImplementedException();
		}

		public void OnUnityAdsShowClick(string placementId)
		{
			throw new System.NotImplementedException();
		}

		public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
		{
			throw new System.NotImplementedException();
		}

		public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
		{
			throw new System.NotImplementedException();
		}

		public void OnUnityAdsShowStart(string placementId)
		{
			throw new System.NotImplementedException();
		}


	}
}

