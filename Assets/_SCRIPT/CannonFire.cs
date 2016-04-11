using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {

	public GameObject bullet;

	public float rateOfFire;

	public float range;

	public Transform muzzle;

	public float lifeSpan;

	void Start () {
		InvokeRepeating ("FireShell", 1, rateOfFire);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void FireShell()
	{
		GameObject bulletClone = (GameObject) Instantiate(bullet, muzzle.position, transform.rotation);
		bulletClone.GetComponent<Rigidbody>().velocity = muzzle.transform.forward * range;
		Destroy (bulletClone, lifeSpan);
	}

}
