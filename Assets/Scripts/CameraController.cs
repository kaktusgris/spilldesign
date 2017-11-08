using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject background;

	private Vector3 offset;


	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// Update is called once per frame (last)
	void LateUpdate () {
		transform.position = player.transform.position + offset;
		//transform.rotation = background.transform.rotation;
	}
}
