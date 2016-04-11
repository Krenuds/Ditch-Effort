using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;

	public float CountDownTimer = 2;



	void Awake () {
		CountDownTimer *= 60;
		instance = this;
	}
	

	void Update () {
	
	}
}
