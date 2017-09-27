using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//rigidbody.useGravity = true;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = 0;
		transform.position = pos;
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Goal"))
		{
			other.gameObject.SetActive (false);
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Scene02");
		}
	}
}
