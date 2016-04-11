using UnityEngine;
using System.Collections;
using System;

public class PhysicsGravityModifier : MonoBehaviour {
	public float multiplier = 1.0f;
	// Use this for initialization
	void Start () {
	
	}


	void FixedUpdate()
	{
		gameObject.GetComponent<Rigidbody> ().AddForce (new Vector3(0, (-Physics.gravity * gameObject.GetComponent<Rigidbody>().mass * multiplier).y,0));
	}
	// Update is called once per frame
	void Update () {

	}
}
