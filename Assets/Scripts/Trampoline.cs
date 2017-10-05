using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public int trampolineForce;
    public Collision collision;
    public bool bounce;

	// Use this for initialization
	void Start () {
        bounce = false;
        trampolineForce = 10;
	}
	
	// Update is called once per frame
	void Update () {
        if (bounce){
            collision.rigidbody.AddForce(transform.up * trampolineForce, ForceMode.Impulse);
            bounce = false;
        }
	}

    void OnCollisionEnter(Collision collision){
        Debug.Log("Jump now");
        if (collision.gameObject.CompareTag("Player")) {
            bounce = true;
            this.collision = collision;
            
        }
    }
}
