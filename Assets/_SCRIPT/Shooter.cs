using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	
	public float force;
	private Rigidbody playerRigid;
	void Start () {
		
	}
	
	
	public void OnTriggerEnter(Collider other)
	{
		playerRigid = other.gameObject.GetComponent<Rigidbody> ();
		if (other.gameObject.tag == "Player") {
			playerRigid.velocity = transform.forward * force;
		}
		
	}
}
