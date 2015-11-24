using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

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

		InputManager.Instance.OnJumpInput += OnJumpEvent;
	}

	private void Update ()
	{
		//move right
		float val = Speed * Time.deltaTime;
		body.velocity = new Vector2 (val, body.velocity.y);
		/*else if (Input.GetKey(KeyCode.LeftArrow))
		{
			float val = Speed * Time.deltaTime;
			body.velocity = new Vector2 (-val, body.velocity.y);
		}*/
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

	private void OnJumpEvent()
	{
		if (!Jumping)
		{
			body.velocity = new Vector2(body.velocity.x, JumpHeigth);
			Jumping = true;
			LaunchJumpAnim();
		}
		else if (!DoubleJumping)
		{
			body.velocity = new Vector2(body.velocity.x, JumpHeigth);
			Jumping = true;
			DoubleJumping = true;
			LaunchJumpAnim();
		}
	}
}
