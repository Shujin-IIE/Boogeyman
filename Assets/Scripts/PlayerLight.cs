using UnityEngine;
using System.Collections;

public class PlayerLight : MonoBehaviour {

	private Light LightComponent;

	// Singleton
	public static PlayerLight Instance
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

	// Use this for initialization
	void Start () {
		LightComponent = GetComponentInChildren<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddLuminosity (float value) {
		LightComponent.intensity += value;
	}
}
