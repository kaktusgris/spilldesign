using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	float counter = 0;
	Vector3 direction;
	float movement;

	// Use this for initialization
	void Start () {
		direction = new Vector3 (0, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (counter > 10) {
			direction.y = -1;
		} else if (counter < 0) {
			direction.y = 1;
		}

		movement = direction.y * Time.deltaTime;
		counter += movement;
		transform.position = new Vector3 (pos.x, pos.y + movement, pos.z);
	}
}
