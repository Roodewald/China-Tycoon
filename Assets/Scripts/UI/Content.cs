using UnityEngine;

namespace ToasterGames
{
	public class Content : MonoBehaviour
	{
		public Bench myBench;

		public void OnClick()
		{
			UIManager.Instance.uIContent.UpdateName(myBench);
		}
	}
}
