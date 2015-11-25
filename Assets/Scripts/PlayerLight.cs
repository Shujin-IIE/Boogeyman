using UnityEngine;
using System.Collections;

public class PlayerLight : MonoBehaviour {

	private Light LightComponent;

	[SerializeField]
	private float DiminishValue = 0.5f;
	[SerializeField]
	private float DeltaDiminishTime = 2f;

	private Timer DiminishTimer;

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
		DiminishTimer = new Timer(DeltaDiminishTime);
	}
	
	// Update is called once per frame
	void Update () {
		DiminishLightOverTime();
	}

	public void AddLuminosity (float value) {
		LightComponent.intensity += value;
	}

	private void DiminishLightOverTime () {
		DiminishTimer.UpdateTimer(Time.deltaTime);

		if (DiminishTimer.IsFinished()) {
			AddLuminosity(-DiminishValue);
			DiminishTimer.Reset();
		}
	}
}
