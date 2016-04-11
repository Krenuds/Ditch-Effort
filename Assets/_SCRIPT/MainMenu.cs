using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public GameObject credits;
	bool show = false;

	public void Start()
	{

	}

	public void Update()
	{

	}
	public void StartGame()
	{
		Application.LoadLevel ("LevelOne");
	}
	public void ShowCredits()
	{
		credits.SetActive (!show);
		show = !show;
	}
	public void ExitGame()
	{
		Application.Quit ();
	}


}
