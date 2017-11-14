using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.SetActive(false);
            //Scene currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

			//First fades in a black screen and then loads next scene
			SceneFader[] faders = GameObject.FindObjectsOfType<SceneFader>();
			foreach (SceneFader fader in faders){
				if (fader.CompareTag("Death")) {
					StartCoroutine(fader.FadeAndLoadScene(SceneFader.FadeDirection.In,SceneManager.GetActiveScene().buildIndex));
				}
			}
            //UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene.name);
        }
    }
}
