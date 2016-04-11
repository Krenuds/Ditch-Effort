using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentQuest : MonoBehaviour {
	public static CurrentQuest instance;

	public Text questTitle;
	public Text questObjective;
	public Text questDescription;
	public Button questButton;
	public GameObject currentQuestObject;

	void Awake () {
		instance = this;
	}

	void Start ()
	{
		gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenQuestPanel()
	{
		Debug.Log (gameObject.activeSelf);
		gameObject.SetActive (true);
	}
	
}
