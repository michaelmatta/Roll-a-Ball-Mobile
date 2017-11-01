using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed; // since it's public it shows up in editor!!
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;
	private float xOffset;
	private float zOffset;

	void Start() // called on first frame
	{
		count = 0;
		SetCountText();
		winText.text = "";
		rb = GetComponent<Rigidbody> ();

		xOffset = Input.acceleration.x;
		zOffset = -Input.acceleration.z;
	}

	void FixedUpdate() //physics updates - use command + ' with highlighted thing for possible functions (Input, RigidBody)
	{ 
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = -Input.acceleration.z;

		Vector3 movement = new Vector3 (moveHorizontal - xOffset, 0.0f, moveVertical - zOffset);

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