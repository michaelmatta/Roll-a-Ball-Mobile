using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
	
	// Update is called once per frame
	void Update () 
	{ // not using forces - just need this baby
		transform.Rotate(new Vector3(15,30,45) * Time.deltaTime); //framerate independent
	}
}
