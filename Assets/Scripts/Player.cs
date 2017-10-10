using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	bool PushedTop, PushedBottom, PushedLeft, PushedRight;
	private bool debug = false;
	private float yPos;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		yPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (PushedTop && PushedBottom) {
			Debug.Log ("Sqeezed!");
		}
		pos = transform.position;
		pos.y = yPos;
		transform.position = pos;
	}


	void OnCollisionStay(Collision coll) {
		if (coll.gameObject.tag == "MovingPlatform"	) {
			//Check all points of contacts occuring on this object
			for (int i = 0; i < coll.contacts.Length; i++) {

				//Is the collision occuring on the top of player
				if (this.transform.position.z > coll.contacts [i].point.z) {
					//Is it pushing in? or pulling out?
					Vector3 diff = coll.contacts [i].point - coll.contacts [i].normal;
					if (diff.z < 0) {
						PushedTop = true;
						if (debug) {
							Debug.Log ("top");
						}
					}
				} else {
					PushedTop = false;
				}
				//Is the collision occuring to the bottom of player
				if (this.transform.position.z < coll.contacts [i].point.z) {
					//Is it pushing in? or pulling out?
					Vector3 diff = coll.contacts [i].point - coll.contacts [i].normal;
					if (diff.z < 0) {
						PushedBottom = true;
						if (debug) {
							Debug.Log ("bottom");
						}
					}
				} else {
					PushedBottom = false;
				}
				//Is the collision occuring on the left of player
				if (this.transform.position.x > coll.contacts [i].point.x) {
					//Is it pushing in? or pulling out?
					Vector3 diff = coll.contacts [i].point - coll.contacts [i].normal;
					if (diff.x < 0) {
						PushedLeft = true;
						if (debug) {
							Debug.Log ("left");
						}
					}
				} else {
					PushedLeft = false;
				}
				//Is the collision occuring to the right of player
				if (this.transform.position.x < coll.contacts [i].point.x) {
					//Is it pushing in? or pulling out?
					Vector3 diff = coll.contacts [i].point - coll.contacts [i].normal;
					if (diff.x < 0) {
						PushedRight = true;
						if (debug) {
							Debug.Log ("right");
						}
					} else {
						PushedRight = false;
					}
				}
			}
		}
	}
}
