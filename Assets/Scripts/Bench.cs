using UnityEngine;

namespace ToasterGames
{
	public class Bench : Upgradable 
	{
		public GameObject batch;
		public Transform  spawnPoint;
		public int batchId;

		private void Start()
		{
			if (level>0)
			{
				SpawnBatch();
			}
		}

		private void SpawnBatch()
		{
			Batch _batch = Instantiate(batch, spawnPoint.position, Quaternion.identity).GetComponent<Batch>();
			_batch.ico = icon.texture;
			_batch.batchID = batchId;
			_batch.batchCount = 1;
		}
	}

}
