using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
	private Animator Anim;

	private float MinDistance = 25;

	private float MaxDistance = 5;

	private Transform PlayerTransform;

	private bool NotPlayed = true;

	private bool NotEnd = true;

	private void Start () 
	{
		PlayerTransform = GameManager.Instance.GetPlayer().transform;
		Anim = GetComponent<Animator>();
		if (Anim == null)
		{
			Debug.LogWarning("ObstacleAnimation : Animator not found");
		}
	}

	private void Update ()
	{
		if (NotPlayed && NearPlayer())
		{
			Debug.Log ("Play anim");
			Anim.SetInteger("state", 1);
			NotPlayed = false;
		}
		else if (!NotPlayed && NotEnd && !NearPlayer())
		{
			Anim.SetInteger("state", 0);
			NotEnd = false;
		}
	}

	private bool NearPlayer()
	{
		bool b;
		if (transform.position.x > PlayerTransform.position.x)
		{
			b = transform.position.x - PlayerTransform.position.x < MinDistance;
		}
		else
		{
			b = PlayerTransform.position.x - transform.position.x < MaxDistance;
		}
		return b;
	}

	public void ResetAnimState()
	{
		NotPlayed = true;
		NotEnd = true;
	}
}
