using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;


public class Google : MonoBehaviour
{
	private readonly static string adUnitId = "ca-app-pub-8792546007679878/5321551771";
	private RewardedAd rewardedAd;

	public void Start()
	{
		// Initialize the Google Mobile Ads SDK.
		MobileAds.Initialize((InitializationStatus initStatus) =>
		{
			LoadRewardedAd();
		});
	}

	public void LoadRewardedAd()
	{
		// Clean up the old ad before loading a new one.
		if (rewardedAd != null)
		{
			rewardedAd.Destroy();
			rewardedAd = null;
		}

		Debug.Log("Loading the rewarded ad.");

		// create our request used to load the ad.
		var adRequest = new AdRequest.Builder().Build();

		// send the request to load the ad.
		RewardedAd.Load(adUnitId, adRequest,
			(RewardedAd ad, LoadAdError error) =>
			{
				// if error is not null, the load request failed.
				if (error != null || ad == null)
				{
					Debug.LogError("Rewarded ad failed to load an ad " +
								   "with error : " + error);
					return;
				}

				Debug.Log("Rewarded ad loaded with response : "
						  + ad.GetResponseInfo());

				rewardedAd = ad;
			});

		RewardedAd.Load(adUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
		{
			// If the operation failed, an error is returned.
			if (error != null || ad == null)
			{
				Debug.LogError("Rewarded ad failed to load an ad with error : " + error);
				return;
			}

			// If the operation completed successfully, no error is returned.
			Debug.Log("Rewarded ad loaded with response : " + ad.GetResponseInfo());

			// Create and pass the SSV options to the rewarded ad.
			var options = new ServerSideVerificationOptions
								  .Builder()
								  .SetCustomData("SAMPLE_CUSTOM_DATA_STRING")
								  .Build();

	ad.SetServerSideVerificationOptions(options);

		});
	}
	public void ShowRewardedAd()
	{
		if (rewardedAd != null && rewardedAd.CanShowAd())
		{
			rewardedAd.Show((Reward reward) =>
			{
				// TODO: Reward the user.
				Debug.Log("REWARD!");
				rewardedAd.Destroy();
				LoadRewardedAd();
			});
		}
	}
}
