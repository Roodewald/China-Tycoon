using UnityEngine;
using UnityEngine.Purchasing;

namespace ToasterGames
{
	public class PlayStore : MonoBehaviour
	{
		public void ComplitePurchase(Product product)
		{
			Debug.Log($"purchase {product} complite");
		}
		public void CanseledPurchase(Product product,PurchaseFailureReason purchaseFailureReason)
		{
			Debug.Log($"purchase canseled {purchaseFailureReason}");
		}
	}
}
