using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

	public bool rotation = false;
	public bool breath = false;

	public float rotationSpeed = 0;
	public GameObject center = null;
	private Vector3 centerPos;

	public float breathSpeed = 1;
	public float size = 1.5f;
	private float smallest;
	private int bigger = 1;
	private Vector3 breathSpeedVector;

	// Use this for initialization
	void Start () {
		breathSpeedVector = new Vector3 (breathSpeed, breathSpeed, breathSpeed) / 1000;
		smallest = 1 / size;
	}
	
	// Update is called once per frame
	void Update () {
		//Rotates object around other object (or itself if null)
		if (rotation) {
			if (center == null) {
				centerPos = this.transform.position;
			} else {
				centerPos = center.transform.position;
			}
			transform.RotateAround (centerPos, Vector3.forward, rotationSpeed * Time.deltaTime);
		}

		//Makes the object breath (grow and shrink)
		if (breath) {
			if (transform.localScale.x >= size || transform.localScale.x <= smallest) {
				breathSpeedVector *= -1;
			}

			transform.localScale += breathSpeedVector * bigger;
		}
	}
}
