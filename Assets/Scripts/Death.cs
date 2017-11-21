using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour {

	FMOD.Studio.EventInstance deathEv;

	// Use this for initialization
	void Start () {
		deathEv = FMODUnity.RuntimeManager.CreateInstance("event:/Death");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.SetActive(false);

			deathEv.start();
			//Ends the music event loop on player
			other.gameObject.GetComponent<Player>().EndMusicEvent();

			//First fades in a black screen and then loads next scene
			SceneFader[] faders = GameObject.FindObjectsOfType<SceneFader>();
			foreach (SceneFader fader in faders){
				if (fader.CompareTag("Death")) {
					StartCoroutine(fader.FadeAndLoadScene(SceneFader.FadeDirection.In,SceneManager.GetActiveScene().buildIndex));
				}
			}
        }
    }
}
