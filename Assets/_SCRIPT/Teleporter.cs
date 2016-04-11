using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour {
	private bool changing = false;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			if (!changing){
				Debug.Log ("Changing: " + gameObject.transform.name);
				GameObject.Find("_Director").GetComponent<ChangeLevels>().nextScene = gameObject.transform.name;
				GameObject.Find("_Director").GetComponent<ChangeLevels>().endingScene  = true;
				changing = true;
			}
		}
	}
	
}
