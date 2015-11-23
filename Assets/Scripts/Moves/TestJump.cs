using UnityEngine;
using System.Collections;

// Need to be used on a ground that have the tag "Ground"
public class TestJump : MonoBehaviour {

	[SerializeField]
	private float maxJumpValue;

	[SerializeField]
	private float maxJumpChargeTime;

	private float jumpChargeTime;

	private float jumpMultiplier;

	private Rigidbody2D playerRigidBody;
	
	private bool isGrounded;

	private bool hasAlreadyJumped;

	// Use this for initialization
	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D>();

		if (playerRigidBody == null) {
			Debug.LogWarning("TestJump.Start(): rigidbody2D == null");
		}

		jumpChargeTime = 0;

		// Multiplier to give a max value for the jump (100% time <=> 100% jump, linear)
		jumpMultiplier = maxJumpValue / maxJumpChargeTime;

		isGrounded = true; // Not clean but if the player begins on a platform (colliding) this allows him to jump
		hasAlreadyJumped = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Press Space to test the jump
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			Jump();
			hasAlreadyJumped = false;
		}
		// Look if the player has already jumped or reached the max jump charge time
		else if (Input.GetKey(KeyCode.Space) && jumpChargeTime < maxJumpChargeTime && !hasAlreadyJumped) {
			Jump();
		}

		if (Input.GetKeyUp(KeyCode.Space)){
			jumpChargeTime = 0f;
			hasAlreadyJumped = true;
		}

		// Old way to make the jump. Maybe it can still be useful. Need PrepareJump() and OldJump().
		// Old jump: press the jump key. When you release it the jump is done.
		// New jump: press the jump key. The jump is immediately done. Keep holding the key and the jumper will go highter until he reached the max jump value
		//	if (Input.GetKey(KeyCode.Space) && isGrounded) {
		//		PrepareJump();
		//	}
		//	if (Input.GetKeyUp(KeyCode.Space) && isGrounded) {
		//		OldJump();
		//	}
	}

	// Add a bit of velocity to the jumper each time this method is called
	void Jump () {
		jumpChargeTime += Time.deltaTime;

		jumpChargeTime = Mathf.Min(jumpChargeTime, maxJumpChargeTime);

		// Rule of three to have a linear jump
		playerRigidBody.velocity += new Vector2(0f, jumpChargeTime * jumpMultiplier / maxJumpChargeTime);
	}

	// Old jump
	void PrepareJump () {
		jumpChargeTime += Time.deltaTime;

		jumpChargeTime = Mathf.Min(jumpChargeTime, maxJumpChargeTime);
	}

	// Old jump
	void OldJump () {
		float jumpHeight = jumpChargeTime * maxJumpValue / maxJumpChargeTime;

		playerRigidBody.AddForce(Vector3.up * jumpHeight, ForceMode2D.Impulse);

		jumpChargeTime = 0f;
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnCollisionExit2D (Collision2D other) {
		if (other.collider.tag == "Ground") {
			isGrounded = false;
		}
	}

}
