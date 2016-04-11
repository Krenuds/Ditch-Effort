using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeLevels : MonoBehaviour
{
	public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	private bool sceneStarting = true;
	public bool endingScene;// Whether or not the scene is still fading in.
	public string nextScene;
	public GameObject blackoutGO;
	
	Image BlackoutImage;
	
	
	void Start ()
	{
		
		endingScene = false;
		
		BlackoutImage = blackoutGO.GetComponent<Image>();
	}
	
	
	void Update ()
	{
		Debug.Log (endingScene.ToString());
		// If the scene is starting...
		if (sceneStarting){
			blackoutGO.SetActive(true);
			StartScene();
		}
		else 
			
		if (endingScene){
			blackoutGO.SetActive(true);
			EndScene();
		}
	}
	
	
	void FadeToClear ()
	{
		// Lerp the colour of the texture between itself and transparent.
		BlackoutImage.color = Color.Lerp(BlackoutImage.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	
	
	
	void StartScene ()
	{
		// Fade the texture to clear.
		FadeToClear();
		
		// If the texture is almost clear...
		if(BlackoutImage.color.a <= 0.05f)
		{
			// ... set the colour to clear and disable the GUITexture.
			BlackoutImage.color = Color.clear;
			BlackoutImage.enabled = false;
			
			blackoutGO.SetActive(false);
			sceneStarting = false;
		}
	}
	
	
	public void EndScene ()
	{
		
		
		BlackoutImage.enabled = true;
		
		// Start fading towards black.
		BlackoutImage.color = Color.Lerp(BlackoutImage.color, Color.black, fadeSpeed * Time.deltaTime);
		
		// If the screen is almost black...
		if(BlackoutImage.color.a >= 0.95f)
			// ... reload the level.
			Application.LoadLevel(nextScene);
	}
}