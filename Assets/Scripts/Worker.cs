using UnityEngine;
using UnityEngine.AI;

namespace ToasterGames
{
	public class Worker : MonoBehaviour
	{
		public NavMeshAgent agent;
		public Transform[] movingPoints;
		public Transform[] jobPoints;

		public Batch curretBatch = null;
		bool hasBatch = false;
		public bool hasJob = false;
		int currentMovingPointIndex;


		public Transform handsTransform;

		private void Start()
		{
			currentMovingPointIndex = Random.Range(0, movingPoints.Length);
			agent = GetComponent<NavMeshAgent>();
		}
		private void Update()
		{
			if (!hasJob)
			{
				MoveToNextPoint();
			}
			else
			{
				if (!hasBatch)
				{
					if (StopPath())
					{
						curretBatch.transform.SetParent(handsTransform);
						curretBatch.transform.position = handsTransform.position;
						agent.SetDestination(jobPoints[1].position);
						hasBatch = true;
					}
				}
				else
				{
					if (StopPath())
					{
						Destroy(curretBatch.gameObject);
						hasBatch = false;
						hasJob = false;
					}
				}
			}
		}


		public void SetBatch(Batch batch)
		{
			curretBatch = batch;
			hasJob = true;
			agent.SetDestination(jobPoints[0].position);
		}

		private void MoveToNextPoint()
		{
			if (StopPath())
			{
				agent.SetDestination(movingPoints[currentMovingPointIndex].position);
				currentMovingPointIndex = Random.Range(0, movingPoints.Length);
			}
		}
		public bool StopPath()
		{
			float distance = Vector3.Distance(agent.pathEndPosition,transform.position);
			if (distance < 0.5f)
			{
				return true;
			}
			return false;
		}
	}
}