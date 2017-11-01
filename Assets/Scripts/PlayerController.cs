using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; // since it's public it shows up in editor!!
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start() // called on first frame
	{
		count = 0;
		SetCountText();
		winText.text = "";
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate() //physics updates - use command + ' with highlighted thing for possible functions (Input, RigidBody)
	{ 
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You win";
		}
	}
}