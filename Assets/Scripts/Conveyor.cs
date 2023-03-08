using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToasterGames
{
	public class Conveyor : MonoBehaviour
	{
		private Rigidbody rb;
		private Material material;
		[SerializeField] private float speed;

		private void Start()
		{
			rb= GetComponent<Rigidbody>();
			material = GetComponent<Renderer>().material;
		}

		private void FixedUpdate()
		{
			material.mainTextureOffset = new Vector2(Time.time * 10f * Time.deltaTime, 0f);
			Vector3 pos = rb.position;
			rb.position += transform.forward * speed * Time.fixedDeltaTime;
			rb.MovePosition(pos);
		}
	}
}

