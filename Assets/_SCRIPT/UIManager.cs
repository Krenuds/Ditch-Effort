using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public GameObject menu;
	public GameObject PowerUpMenu;
	PlayerManager pMan;
	PlayerController pControl;
	GameObject player;
	private Text timeText;
	private float levelTime = 0.0f;
	

	public GameObject debugText;
	void Start () {
		levelTime = LevelManager.instance.CountDownTimer;
		player = GameObject.Find ("Player");
		pControl = player.GetComponent <PlayerController> ();
		pMan = player.GetComponent<PlayerManager>();
		try{
			timeText = GameObject.Find ("TimeText").GetComponent<Text> ();
		}
		catch (Exception e)
		{
			Debug.Log ("Timer not found, probably in first scene");
			Debug.Log(e.Message);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetButtonDown ("escape"))
			ToggleGameMenu ();
		if(timeText){
			levelTime -= Time.deltaTime;
			timeText.text = Math.Round(levelTime,2).ToString();
			if (levelTime <= 30)
			{
				timeText.color = Color.red;
			}
			if (levelTime <= 0)
			{
				levelTime = 0;
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
	void Update () {


		debugText.GetComponent<Text> ().text =
			"Speed: " + player.GetComponent<Rigidbody> ().velocity.magnitude +
			"\nAltitude: " + player.transform.position.y +
			"\nHealth: " + pMan.health +
			"\nStamina: " + pMan.stamina +
			"\nJump Power: " + pControl.jumpForce +
			"\nMax Move Speed: " + pControl.moveSpeed +
			"\nGrappling: " + pControl.grapple +
			"\nGrapple Location: " + pControl.GrappleLoc();
			

	}
	public void MainMenu()
	{
		Application.LoadLevel ("MainMenu");
	}
	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
	public void ToggleGameMenu()
	{
		menu.SetActive (!menu.activeSelf);
	}

	public void CloseMenu()
	{
		GameObject.Find ("PowerUpPanel").gameObject.SetActive(false);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
	public void LevelSelectButton()
	{
		Application.LoadLevel ("LevelOne");
	}
}
