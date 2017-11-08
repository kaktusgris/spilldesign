using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour {

	public float length = 3;
	public Vector3 direction = new Vector3 (0, 0, 1);
	public float movementSpeed = 1f;
	public float waitTime = 0f;

	private float counter = 0;
	private bool startDirection = true;
	private bool moving = false;

	// Use this for initialization
	void Start () {
		StartCoroutine (initPlatform ());
	}

	// Update is called once per frame
	void Update () {
		if (moving) {
			StartCoroutine (movePlatform ());
		}
	}

	IEnumerator initPlatform(){
		yield return new WaitForSeconds(waitTime);
		moving = true;
	}

	IEnumerator movePlatform (){
		// Changes the direction when the platform has reached the end
		if (counter > length && startDirection) {
			direction = direction * -1;
			startDirection = false;
			moving = false;
			yield return new WaitForSeconds(waitTime);
			moving = true;
		} else if (counter < 0 && !startDirection) {
			direction = direction * -1;
			startDirection = true;
			moving = false;
			yield return new WaitForSeconds(waitTime);
			moving = true;
		}

		float translation = movementSpeed * Time.deltaTime;
		transform.Translate (direction * translation);
		if (startDirection) {
			counter += translation;
		} else {
			counter -= translation;
		}
	}
		

	/*void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag("Player")) {
			float d = Vector3.Distance (collision.gameObject.transform.position, transform.position);
			if (true) {
				Debug.Log(d);
			}
		}
	}*/
}