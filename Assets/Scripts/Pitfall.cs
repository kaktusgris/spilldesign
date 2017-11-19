using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pitfall : MonoBehaviour {
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
            //Reloads the current scene
            Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
        }
    }
}
