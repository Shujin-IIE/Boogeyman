using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/*
 * To add a new object to the factory :
 * Add it to the enum,
 * Create an attribute for the prefab
 * In start, link prefab and enum
 */

//Object types that need to be stored in the factory
public enum Elements {Monster, Rock, Stump1, Stump2, Length /*length of the enum*/};

public class ObstacleFactory : MonoBehaviour 
{
	public static ObstacleFactory Instance
	{
		get;
		private set;
	}
	private void Awake()
	{
		if (Instance != null)
			return;
		Instance = this;
	}

	[SerializeField]
	private GameObject prefabMonster;
	
	[SerializeField]
	private GameObject prefabRock;
	
	[SerializeField]
	private GameObject prefabStump1;
	
	[SerializeField]
	private GameObject prefabStump2;


	private GameObject[] Prefabs = new GameObject[(int) Elements.Length];

	private List<GameObject>[] ObjectList = new List<GameObject>[(int) Elements.Length];

	private void Start()
	{
		for (int i = 0; i<(int)Elements.Length; i++)
		{
			ObjectList[i] = new List<GameObject>();
		}
		//links between prefabs and enum
		Prefabs[(int) Elements.Monster] = prefabMonster;
		Prefabs[(int) Elements.Rock] = prefabRock;
		Prefabs[(int) Elements.Stump1] = prefabStump1;
		Prefabs[(int) Elements.Stump2] = prefabStump2;
	}

	public GameObject GetObject(Elements element)
	{
		List<GameObject> list = ObjectList[(int) element];
		GameObject obj;
		if (list.Count > 0)
		{
			obj = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
		else
		{
			obj = Instantiate(Prefabs[(int) element], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			if (element == Elements.Monster)
			{
				obj.transform.RotateAround(obj.transform.position, transform.up, 180);
			}
			obj.SetActive(false);
		}
		return obj;
	}

	public void DisableObject(GameObject obj, Elements element)
	{
		List<GameObject> list = ObjectList[(int) element];
		obj.SetActive(false);
		obj.transform.localScale = new Vector3(1,1,1);
		if (!list.Contains(obj))
		{
			list.Add(obj);
		}
	}

}
