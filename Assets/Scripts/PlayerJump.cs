using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

	// Jump properties
	[SerializeField]
	private float MaxJumpValue;
	private float JumpMultiplier;

	[SerializeField]
	private float MaxJumpChargeTime;
	private float JumpChargeTime;
	
	private Rigidbody2D PlayerRigidBody;
	
	private bool IsGrounded;
	private bool HasAlreadyJumped;

	private InputManager InputManagerComponent;
	
	// Use this for initialization
	void Start () {
		InputManagerComponent = InputManager.Instance;

		if (InputManagerComponent == null) {
			Debug.LogWarning("PlayerMove.Start(): InputManagerComponent == null");
		}

		InputManagerComponent.OnJumpInput += JumpEventHandler;

		InitJumpState();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Initialize the jump properties
	void InitJumpState () {
		PlayerRigidBody = GetComponent<Rigidbody2D>();
		
		if (PlayerRigidBody == null) {
			Debug.LogWarning("PlayerMove.InitJumpStata(): rigidbody2D == null");
		}
		
		JumpChargeTime = 0;
		
		// Multiplier to give a max value for the jump (100% time <=> 100% jump, linear)
		JumpMultiplier = MaxJumpValue / MaxJumpChargeTime;
		
		IsGrounded = true; // Not clean but if the player begins on a platform (colliding) this allows him to jump
		HasAlreadyJumped = false;
	}

	void JumpEventHandler (JumpEnum e) {
		if (e == JumpEnum.Pressed && IsGrounded) {
			Jump();
			HasAlreadyJumped = false;
		}
		else if (e == JumpEnum.StillPressed && JumpChargeTime < MaxJumpChargeTime && !HasAlreadyJumped) {
			Jump();
		}
		else if (e == JumpEnum.Stop) {
			JumpChargeTime = 0f;
			HasAlreadyJumped = true;
		}
	}

	// Add a bit of velocity to the jumper each time this method is called
	void Jump () {
		JumpChargeTime += Time.deltaTime;
		
		JumpChargeTime = Mathf.Min(JumpChargeTime, MaxJumpChargeTime);
		
		// Rule of three to have a linear jump
		PlayerRigidBody.velocity += new Vector2(0f, JumpChargeTime * JumpMultiplier / MaxJumpChargeTime);
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.tag == "Ground") {
			IsGrounded = true;
		}
	}
	
	void OnCollisionExit2D (Collision2D other) {
		if (other.collider.tag == "Ground") {
			IsGrounded = false;
		}
	}
}
