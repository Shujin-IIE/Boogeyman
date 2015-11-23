using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance
	{
		get;
		private set;
	}
	
	private GameObject Player;

	private void Awake()
	{
		if (Instance != null)
			return;
		Instance = this;
	}

	void Start ()
	{
		
	}

	void Update ()
	{
	
	}

	public void SetPlayer(GameObject player)
	{
		Player = player;
	}

	public GameObject GetPlayer()
	{
		return Player;
	}
}
