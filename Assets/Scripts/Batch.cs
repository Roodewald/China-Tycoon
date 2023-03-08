using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToasterGames
{
	public class Batch : MonoBehaviour
	{
		public Texture ico;
		public GameObject[] quads;

		private void Start()
		{
			foreach (GameObject quad in quads)
			{
				quad.GetComponent<Renderer>().material.mainTexture = ico;
			}
		}
	}
}