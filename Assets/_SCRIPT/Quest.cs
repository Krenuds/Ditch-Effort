using UnityEngine;
using System.Collections;

public class Quest : MonoBehaviour {

	public string questTitle;
	public string questObjective;
	public string questDescription;

	CurrentQuest currentQuest;

	public bool destroyable = true;

	void Start () {
		currentQuest = CurrentQuest.instance;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnTriggerEnter(Collider other)
	{
		currentQuest.OpenQuestPanel ();
		currentQuest.questTitle.text = questTitle;
		currentQuest.questObjective.text = questObjective;
		currentQuest.questDescription.text = questDescription;
		if (destroyable) Destroy (this.gameObject);

	}
}
