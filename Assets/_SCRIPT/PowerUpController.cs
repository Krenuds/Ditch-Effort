using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {
	public GameObject Player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Object OBJ){
		Player.GetComponent<Animation>().Play();
	}
}
