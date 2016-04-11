using UnityEngine;
using System.Collections;

public class PowerUpMachine : MonoBehaviour {
	
	private bool powerUpSelected = false;
	public GameObject powerUpMenu;
	
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !powerUpSelected ) {
			powerUpMenu.SetActive(true);
			powerUpSelected = true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && other.name != "Sanic Ball") {
			other.GetComponent<Animator>().SetBool("PoweringUp", true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && other.name != "Sanic Ball") {
			other.GetComponent<Animator>().SetBool("PoweringUp", false);
			powerUpMenu.SetActive(false);
		}
	}
}
