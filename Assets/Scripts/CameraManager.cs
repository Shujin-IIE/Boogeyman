using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	[SerializeField]
	private Vector3 Offset = new Vector3(0,0,0);

	private Transform PlayerTransform;
	
	void Start ()
	{
		PlayerTransform = GameManager.Instance.GetPlayer().transform;
	}

	void Update ()
	{
		transform.position = new Vector3(Offset.x + PlayerTransform.position.x, Offset.y + PlayerTransform.position.y, Offset.z + PlayerTransform.position.z);
	}
}
