using UnityEngine;
using System.Collections;

// JumpEnum
public enum JumpEnum {
	Pressed,
	StillPressed,
	Stop
}

// Receive the events from the user
public class InputManager : MonoBehaviour {

	// Singleton
	public static InputManager Instance
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

	// Jump Event
	public delegate void JumpInput (JumpEnum e);
	public event JumpInput OnJumpInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		IsJumpInput();
	}

	void IsJumpInput () {
		if (OnJumpInput != null) {
			if (Input.GetButtonDown("Jump")) {
				OnJumpInput(JumpEnum.Pressed);
			}
			else if (Input.GetButton("Jump")) {
				OnJumpInput(JumpEnum.StillPressed);
			}
			else if (Input.GetButtonUp("Jump")) {
				OnJumpInput(JumpEnum.Stop);
			}
		}
	}
}
