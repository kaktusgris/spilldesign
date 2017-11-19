using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceMusicController : MonoBehaviour {

    private FMOD.Studio.EventInstance ambienceEv;
    
    void Awake(){
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start () {
        ambienceEv = FMODUnity.RuntimeManager.CreateInstance("event:/RollingBall2");
        ambienceEv.start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
