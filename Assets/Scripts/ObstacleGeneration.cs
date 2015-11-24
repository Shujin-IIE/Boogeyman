using UnityEngine;
using System.Collections;

public class ObstacleGeneration : MonoBehaviour
{
	private int Difficulty = 1;

	private float minDistance = 40;

	private float maxDistance = 80f;
	
	private Transform PlayerTransform;

	private float NextObjectPos = 100f;

	private float OffsetY = -8.4f;


	private void Start ()
	{
		PlayerTransform = GameManager.Instance.GetPlayer().transform;
	}

	private void Update ()
	{
		if (PlayerTransform.position.x + 100 > NextObjectPos)
		{
			CreateObstacle();
			NextObjectPos += Random.Range (minDistance, maxDistance);
		}
	}

	private void CreateObstacle()
	{
		Debug.Log ("New obstacle");
		int type = Random.Range (0, 4);
		float scale = Random.Range (0.5f, 2.0f);
		GameObject obstacle = ObstacleFactory.Instance.GetObject((Elements) type);
		obstacle.GetComponent<ObstacleBehavior>().SetType((Elements) type);
		obstacle.SetActive(true);
		if (type == 0)
		{
			obstacle.transform.position = new Vector3(NextObjectPos, -9.5f, 0);
			if (scale > 0.7f) scale = 0.7f;
		}
		else
		{
			obstacle.transform.position = new Vector3(NextObjectPos, OffsetY, 0);
		}
		obstacle.transform.localScale = new Vector3(scale, scale, scale);
	}
}
