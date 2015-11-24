using UnityEngine;
using System.Collections;


// Receive the events from the user
public class InputManager : MonoBehaviour
{

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
	public delegate void JumpInput();
	public event JumpInput OnJumpInput;
	
	void Start ()
	{
	
	}

	void Update ()
	{
		IsJumpInput();
	}

	void IsJumpInput ()
	{
		if (OnJumpInput != null)
		{
			if (Input.GetButtonDown("Jump"))
			{
				OnJumpInput();
			}
		}
	}
}
