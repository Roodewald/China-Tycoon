using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class InternalAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
	public static InternalAds instance;

	private static string andriodAdId = "Interstitial_Android";
	private static string iosAdeId = "Interstitial_iOS";

	private string adId;

	private void Awake()
	{
		instance = this;
		adId = (Application.platform == RuntimePlatform.Android) ? andriodAdId : iosAdeId;
	}

	public void LoadAd()
	{
		Debug.Log("Loading Ad: " + adId);
		Advertisement.Load(adId, this);
	}
	public void ShowAd()
	{
		Debug.Log("Showing ad" + adId);
		Advertisement.Show(adId, this);
	}

	public void OnUnityAdsAdLoaded(string placementId)
	{
		Debug.Log("Ad loaded" + placementId);
	}

	public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
	{
		Debug.Log($"FailLoadAdd ID:{placementId}, E:{error}, Message{message}");
	}

	public void OnUnityAdsShowClick(string placementId)
	{
		throw new NotImplementedException();
	}

	public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
	{
		LoadAd();
	}

	public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
	{
		Debug.Log($"FailShowAdd ID:{placementId}, E:{error}, Message{message}");
	}

	public void OnUnityAdsShowStart(string placementId)
	{
		throw new NotImplementedException();
	}
}
