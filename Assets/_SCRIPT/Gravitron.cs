using UnityEngine;
using System.Collections;

public class Gravitron : MonoBehaviour {

	private bool triggered = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (!triggered) {
			if (other.tag == "Player") {
				Debug.Log ("Gravity Shifted");
				PlayerController.instance.jumpForce = -PlayerController.instance.jumpForce;
				Physics.gravity = new Vector3(0,-Physics.gravity.y,0);
				triggered = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		triggered = false;
	}
}
