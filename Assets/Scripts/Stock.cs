using UnityEngine;

namespace ToasterGames
{
	public class Stock : MonoBehaviour, IInteractable
	{
		private UIManager uIManager;
		public int[] storage;

		private void Start()
		{
			uIManager = UIManager.Instance;
		}

		public void Interact()
		{
			uIManager.SetActivePanel(2);

			
			CameraController.instance.SetShowingObject(gameObject);
		}

		public void AddBatchInStock(Batch batch)
		{
			storage[batch.batchID] += batch.batchCount;
			PlayerProfile.instance.Save();
		}
	}
}