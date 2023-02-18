using UnityEngine;
using TMPro;

namespace ToasterGames
{
	public class UIContent : MonoBehaviour
	{
		public Content contentPrefab;
		public Transform contentTransform;
		[SerializeField] private TMP_Text becnhName;
		[SerializeField] private TMP_Text benchDiscription;
		[SerializeField] private TMP_Text benchLevel;

		public void CreateContentButton(Bench[] benches)
		{
			if (benches != null)
			{
				foreach (Bench bench in benches)
				{
					Content createdPrefab = Instantiate(contentPrefab, contentTransform);
					createdPrefab.myBench= bench;
				}
			}
		}

		public void UpdateName(Bench bench)
		{
			becnhName.text= bench.benchName;
			benchDiscription.text= bench.discription;
			benchLevel.text = bench.level.ToString();
		}
	}

}
