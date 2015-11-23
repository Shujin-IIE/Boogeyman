using UnityEngine;
using System.Collections;

public class MapGeneration : MonoBehaviour {

	[SerializeField]
	private GameObject prefabBackground;
	
	[SerializeField]
	private GameObject prefabGrass;

	[SerializeField]
	private GameObject prefabPlayer;

	[SerializeField]	
	private float BackgroundWidth = 187.66f;

	[SerializeField]
	private float GrassWidth = 196.62f;

	private Transform PlayerTransform;

	private GameObject Background1;

	private GameObject Background2;

	private GameObject Grass1;
	
	private GameObject Grass2;
	
	private void Start ()
	{
		GameObject Player = Instantiate(prefabPlayer, new Vector3(12, -8, 0), Quaternion.identity) as GameObject;
		GameManager.Instance.SetPlayer(Player);
		PlayerTransform = Player.GetComponent<Transform>();

		Background1 = Instantiate(prefabBackground, new Vector3(0, 0, 10), Quaternion.identity) as GameObject;
		Background2 = Instantiate(prefabBackground, new Vector3(BackgroundWidth, 0, 10), Quaternion.identity) as GameObject;

		Grass1 = Instantiate(prefabGrass, new Vector3(0, -9.6f, 10), Quaternion.identity) as GameObject;
		Grass2 = Instantiate(prefabGrass, new Vector3(GrassWidth, -9.6f, 10), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		if (Background1.transform.position.x < PlayerTransform.position.x - 50 && ChildrenInvisible(Background1))
		{
			Background1.transform.Translate(2*BackgroundWidth, 0, 0);
			Debug.Log ("moving bg1");
		}
		if (Background2.transform.position.x < PlayerTransform.position.x - 50 && ChildrenInvisible(Background2))
		{
			Background2.transform.Translate(2*BackgroundWidth, 0, 0);
			Debug.Log ("moving bg2");
		}
		if (Grass1.transform.position.x < PlayerTransform.position.x - 50 && ChildrenInvisible(Grass1))
		{
			Grass1.transform.Translate(2*GrassWidth, 0, 0);
			Debug.Log ("moving grass1");
		}
		if (Grass2.transform.position.x < PlayerTransform.position.x - 50 && ChildrenInvisible(Grass2))
		{
			Grass2.transform.Translate(2*GrassWidth, 0, 0);
			Debug.Log ("moving grass2");
		}
	}

	private bool ChildrenInvisible(GameObject go)
	{
		bool b = true;
		Transform trans = go.transform;
		for (int i=0; i<trans.childCount; i++)
		{
			b = b && (!trans.GetChild(i).gameObject.GetComponent<SpriteRenderer>().isVisible);
		}
		return b;
	}


}
