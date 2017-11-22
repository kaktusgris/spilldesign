using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("escape")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
	}
}
