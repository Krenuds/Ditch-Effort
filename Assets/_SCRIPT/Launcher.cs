using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	public Vector3 direction;
	public float force;
	private Rigidbody playerRigid;
	void Start () {
	
	}


	public void OnTriggerEnter(Collider other)
	{
		playerRigid = other.gameObject.GetComponent<Rigidbody> ();
		if (other.gameObject.tag == "Player") {
			playerRigid.velocity = direction * force;
		}

	}
}
