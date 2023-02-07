using UnityEngine;
using UnityEngine.Advertisements;

namespace ToasterGames
{
	public class AdsInstaller : MonoBehaviour, IUnityAdsInitializationListener
	{
		private static string andriodGameId = "5154199";
		private static string iosGameId = "5154198";
		private string gameId;

		[SerializeField] private bool testMode = true;

		private void Awake()
		{
			InitializeAds();
		}

		private void InitializeAds()
		{
			gameId = (Application.platform == RuntimePlatform.Android) ? andriodGameId : iosGameId;
			Advertisement.Initialize(gameId, testMode, this);
		}

		public void OnInitializationComplete()
		{
			Debug.Log("Unity Ads initialization complite.");
			InternalAds.instance.LoadAd();
			RewardedAds.instance.LoadRAd();
		}

		public void OnInitializationFailed(UnityAdsInitializationError error, string message)
		{
			Debug.LogError($"Unity Ads initialization Failed:. {error.ToString()} - {message}");
		}
	}
}
