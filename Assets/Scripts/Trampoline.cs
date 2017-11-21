using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

	public int intensity = 10;

    private Collision collision;
    private bool bounce;

	FMOD.Studio.EventInstance jumpEv;

	// Use this for initialization
	void Start () {
		bounce = false;
		jumpEv = FMODUnity.RuntimeManager.CreateInstance("event:/Jump");
	}
	
	// Update is called once per frame
	void Update () {
        if (bounce){
			//collision.rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
			collision.rigidbody.AddForce(this.gameObject.transform.up * -intensity, ForceMode.Impulse);

            bounce = false;
        }
	}

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Player")) {
			jumpEv.start();
            bounce = true;
            this.collision = collision;
        }
    }
}
