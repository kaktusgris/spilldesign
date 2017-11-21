using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour {

	FMOD.Studio.EventInstance goalEv;

	// Use this for initialization
	void Start () {
		goalEv = FMODUnity.RuntimeManager.CreateInstance("event:/GoalSound");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Player")){
			//Plays goal event
			goalEv.start();
			other.gameObject.SetActive(false);
			//Ends the music event loop on player
			other.gameObject.GetComponent<Player>().EndMusicEvent();

			//Makes the goal "invisible"
			Vector3 away = new Vector3 (0, 0, 100);
			transform.position = away;
			UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
