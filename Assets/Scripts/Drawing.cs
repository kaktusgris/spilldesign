using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawing : MonoBehaviour {

	float x = 0.0f;
	float y = 0.0f;

	// Use this for initialization
	void Start () {
		
	}

	void Coordinates () {
		x = Input.mousePosition.x;
		y = Input.mousePosition.y;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Coordinates ();
			Debug.Log (x + ", " + y);
		}
	}
}
