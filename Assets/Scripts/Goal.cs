using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

    void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Player")){
            other.gameObject.SetActive(false);

			//Makes the goal "invisible"
			Vector3 away = new Vector3 (0, 0, 100);
			transform.position = away;

            //First fades in a black screen and then loads next scene
			StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.In,SceneManager.GetActiveScene().buildIndex + 1));
        }
    }
		
}
