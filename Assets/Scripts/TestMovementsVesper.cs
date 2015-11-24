using UnityEngine;
using System.Collections;

public class TestMovementsVesper : MonoBehaviour {

	[SerializeField]
	private float Speed = 0.001f;

	[SerializeField]
	private float JumpHeigth = 10f;

	private Rigidbody2D body;

	private Animator Anim;

	private bool Jumping = false;

	private bool DoubleJumping = false;

	private void Start ()
	{
		body = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
	}

	private void Update ()
	{
		//move left and right
		if (Input.GetKey(KeyCode.RightArrow))
		{
			float val = Speed * Time.deltaTime;
			body.velocity = new Vector2 (val, body.velocity.y);
		}
		else if (Input.GetKey(KeyCode.LeftArrow))
		{
			float val = Speed * Time.deltaTime;
			body.velocity = new Vector2 (-val, body.velocity.y);
		}
		else
		{
			body.velocity = new Vector2(0, body.velocity.y);
		}

		//jump
		if (Input.GetButtonDown("Jump"))
		{
			if (!Jumping)
			{
				Debug.Log ("jump");
				float val = JumpHeigth;
				body.velocity = new Vector2(body.velocity.x, val);
				Jumping = true;
				LaunchJumpAnim();
			}
			else if (!DoubleJumping)
			{
				Debug.Log ("double jump");
				float val = JumpHeigth;
				body.velocity = new Vector2(body.velocity.x, val);
				Jumping = true;
				DoubleJumping = true;
				LaunchJumpAnim();
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other) {
		Debug.Log ("collision enter");
		if (other.collider.CompareTag("Ground")) {
			Jumping = false;
			DoubleJumping = false;
			EndJumpAnim();
		}
	}

	private void LaunchJumpAnim()
	{
		Anim.SetInteger("state", 1);
	}

	private void EndJumpAnim()
	{
		Anim.SetInteger("state", 0);
	}
	
	/*void OnCollisionExit2D (Collision2D other) {
		Debug.Log ("collision exit");
		if (other.collider.CompareTag("Ground")) {
			Grounded = false;
		}
	}*/
}
