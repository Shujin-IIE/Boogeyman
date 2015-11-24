using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
	private Elements Type;
	
	private void OnTriggerEnter2D()
	{
		GameManager.Instance.GetPlayer().GetComponent<PlayerMove>().SlowPlayer();
		ObstacleFactory.Instance.DisableObject(gameObject, Type);
	}

	private void OnBecameInvisible()
	{
		if (Type == Elements.Monster)
		{
			GetComponent<ObstacleAnimation>().ResetAnimState();
		}
		ObstacleFactory.Instance.DisableObject(gameObject, Type);
	}

	public void SetType(Elements type)
	{
		Type = type;
	}
}
