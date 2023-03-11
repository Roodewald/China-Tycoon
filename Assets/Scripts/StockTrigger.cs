using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ToasterGames
{
	public class StockTrigger : MonoBehaviour
	{
		private List<Batch> aviableBatches = new();
		[SerializeField] private Stock stock;
		[SerializeField] private Worker[] workerks;

		private void OnTriggerEnter(Collider other)
		{
			if (other.GetComponent<Batch>())
			{
				Batch batch = other.GetComponent<Batch>();

				if (!batch.counted)
				{
					stock.AddBatchInStock(batch);
					batch.GetComponent<Rigidbody>().isKinematic = true;
					batch.counted = true;
					aviableBatches.Add(batch);
				}
			}
		}
		private void Update()
		{
			if (aviableBatches.Count > 0)
			{
				foreach (Worker worker in workerks)
				{
					if (!worker.hasJob)
					{
						Debug.Log("Common");
						if (aviableBatches.Any())
						{
							Batch batch = aviableBatches.First();
							worker.SetBatch(batch);
							aviableBatches.Remove(batch);
						}
					}
				}
			}
		}


	}
}
