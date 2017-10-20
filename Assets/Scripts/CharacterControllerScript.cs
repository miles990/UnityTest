using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour {

	public float maxSpeed = 10f;
	public float speedRate = 1f;
	bool facingRight = true;

	private Rigidbody2D rb;
	Animator anim;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		#if UNITY_IPHONE
		float move = Input.acceleration.x;
		#elif UNITY_ANDROID
		float move = Input.acceleration.x;
		#else
		float move = Input.GetAxis ("Horizontal");
		#endif

		rb.velocity = new Vector2 (move * maxSpeed, rb.velocity.y * speedRate);

		anim.SetFloat ("Speed", Mathf.Abs (move));

		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();
		}
	}

	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
