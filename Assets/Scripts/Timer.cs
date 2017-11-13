using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public bool timeStop;
	public Text time;

	// Use this for initialization
	void Start () {
		if (timeStop) {
			time.text = ((Time.time - GlobalGameState.startTime).ToString ("F2"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!timeStop) {
			time.text = (Time.time - GlobalGameState.startTime).ToString ("F2");
		}
	}
}
