using UnityEngine;
using System.Collections;

public class HeadLights : MonoBehaviour {

	Transform player;
	Transform mainCamera;

	public float rotationOffsetX;
	public float rotationOffsety;
	public float rotationOffsetZ;

	public float positionOffsetX;
	public float positionOffsety;
	public float positionOffsetZ;

	public float speed;

	bool attached = false;

	void Start () {

			player = GameObject.Find ("PlayerModel").transform;
			mainCamera = GameObject.Find ("Main Camera").transform;
		

	}
	
	// Update is called once per frame
	void Update () {
		if (attached) {
			transform.rotation = Quaternion.Euler (-mainCamera.eulerAngles.x + rotationOffsetX, mainCamera.eulerAngles.y - 180, 0);
			transform.position = player.position;
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			attached = true;
		}
	}
}
