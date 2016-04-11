using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public int health = 100;
	public int stamina = 100;
	public float yKillLow = -10;
	public float yKillHigh = 500;

	PlayerController pControl;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}

		if (transform.position.y < yKillLow)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		if (transform.position.y > yKillHigh)
		{
			Physics.gravity = new Vector3(0,-Physics.gravity.y,0);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (stamina < 0) {
			stamina = 0;
		}
	}

	private void OnTriggerEnter(Collider obj)
	{
		Debug.Log ("Collided With:" + obj.transform.name);
		if (obj.gameObject.tag == "Token") {
			Destroy(obj.gameObject.transform.parent.gameObject);
		}
		if (obj.gameObject.tag == "Spike") {
			health-=10;
			PlayerController.instance.DamageJump(1);
		}
	}
}
