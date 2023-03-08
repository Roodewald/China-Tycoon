using UnityEngine;

namespace ToasterGames
{
	public class Bench : Upgradable 
	{
		public GameObject batch;
		public Transform  spawnPoint;

		private void Start()
		{
			if (level>0)
			{
				SpawnBatch();
			}
		}

		private void SpawnBatch()
		{
			Instantiate(batch, spawnPoint.position, Quaternion.identity).GetComponent<Batch>().ico = icon.texture;
		}
	}

}
