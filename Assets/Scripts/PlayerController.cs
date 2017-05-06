using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text scoreText;
	public Text winText;

	private Rigidbody rb;
	private int score;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetScoreText ();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Food")) {
			other.gameObject.SetActive (false);
			score += 1;
			SetScoreText ();
		}
	}

	void SetScoreText () {
		scoreText.text = "Score: " + score;
		if (score >= 12) {
			winText.text = "You win!";
		}
	}
}
