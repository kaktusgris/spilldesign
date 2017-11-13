using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public GameObject background;

	//private Vector3 pos;
	private Vector3 origin = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {
		//pos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float rotateClockwise = Input.GetAxis ("Horizontal") * - 0.8f;

		transform.RotateAround (origin, Vector3.forward, rotateClockwise);
		background.transform.Rotate (new Vector3(0, 0, rotateClockwise * 0.9f));

		//transform.Rotate (new Vector3 (0, 0, rotateClockwise));
	}

}