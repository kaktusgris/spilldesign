using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float rotateClockwise = Input.GetAxis ("Horizontal") * 1.5f;

		transform.Rotate (new Vector3 (0, rotateClockwise, 0));
	}
}
