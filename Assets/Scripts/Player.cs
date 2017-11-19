using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float ballVelocity;

    private FMOD.Studio.EventInstance rollingEv;
    private FMOD.Studio.ParameterInstance rollingLoop;
    private FMOD.Studio.ParameterInstance rollingIn;

    bool PushedTop, PushedBottom, PushedLeft, PushedRight;
    //private bool debug = false;

    //public function that makes sure that the event stops looping when a new scene is loaded
    public void EndMusicEvent()
    {
        rollingLoop.setValue(1.0f);
    }

    // Use this for initialization
    void Start () {


        rollingEv = FMODUnity.RuntimeManager.CreateInstance("event:/RollingBall2");
        rollingEv.getParameter("RollingIn", out rollingIn);
        rollingEv.getParameter("End", out rollingLoop);

        //Make sure that we do not send null parameters
        if (rollingEv.getParameter("RollingIn", out rollingIn) != FMOD.RESULT.OK)
        {
            Debug.LogError("Can't find Game parameter on the event");
        }
        rollingEv.start();
    }

	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("z") && Input.GetKey ("m") && SceneManager.GetActiveScene().buildIndex > 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
    }

    void OnCollisionStay(Collision coll) {
        
        //While the player is on a wall, the music event is played in relation to the player's velocity
        if (coll.gameObject.CompareTag("Wall")){
            ballVelocity = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            float rollingParam = Mathf.Log(ballVelocity*5)/4;
            Debug.Log(rollingParam);
            rollingIn.setValue(rollingParam);
        }
    } 

    //Turns off the music event when the player is no longer touching a wall
    void OnCollisionExit(Collision coll){
        if (coll.gameObject.CompareTag("Wall"))
        {    
            rollingIn.setValue(0);
        }
    }
}
