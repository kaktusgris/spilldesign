using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameState : MonoBehaviour {

	public static float startTime;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {
	}

	public void Play () {
		startTime = Time.time;
		UnityEngine.SceneManagement.SceneManager.LoadScene("01Intro");
	}
}
