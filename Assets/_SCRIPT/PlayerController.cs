using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public static PlayerController instance;

	float hAxis;
	float vAxis;
	float zAxis;

	public float grappleFallOff;
	public float maxVelocity = 100;
	public float acelleration = 1;
	Camera mainCam;
	bool isGrounded = true;
	Rigidbody player;

	public float moveSpeed = 1;
	public float speedBoost = 2;
	public float airMoveDamp = 2;
	public float jumpForce = 10;
	public float jumpForceBoostPower = 20;
	public float grappleSpeed = 1;
	public bool grapple;

	private Vector3 grappleLoc;
	private Vector3 grappleDir;
	PlayerManager pMan;

	public int staminaRegenTick = 2;

	public GameObject grapplingHook;
	private LineRenderer grappleLine;



	void Awake()
	{
		instance = this;
	}

	void Start () {

		grappleLine = grapplingHook.GetComponent<LineRenderer> ();

		mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
		player = gameObject.GetComponent<Rigidbody> ();
		player.maxAngularVelocity = maxVelocity;
		pMan = player.GetComponent<PlayerManager>();
		StartCoroutine (addStamina ());
	}
	
	void Update()
	{
		if (Input.GetKeyDown ("g") && pMan.stamina >=50) Grapple();
		
		if (grapple && Input.GetKey("g") && (player.transform.position - grappleLoc).magnitude > grappleFallOff )
		{
			grappleLine.enabled = true;
			grappleLine.SetPosition (0, player.transform.position);
			player.velocity = (grappleDir) * grappleSpeed ;
			player.useGravity = false;

		}
		else 
		{
			grappleLine.enabled = false;
			player.useGravity = true;
			grapple = false;
		}

		if (Input.GetButtonDown ("Boost")) {
			moveSpeed *= 2;
		} 
		if (Input.GetButtonUp ("Boost")) {
			moveSpeed /= 2;
		} 
		
	}

	void LateUpdate()
	{
		if (Input.GetButtonDown ("Jump") && isGrounded) {
			Jump ();
		}
	}

	public void Jump()
	{
			isGrounded = false;
			player.velocity += Vector3.up * jumpForce * 10;

	}

	public void DamageJump(float force)
	{
		isGrounded = false;
		player.velocity += Vector3.up * force * 10;
		
	}
	IEnumerator addStamina(){
		while (true) { // loops forever...
			if (pMan.stamina < 100) { // if health < 100...
				pMan.stamina += 1; // increase health and wait the specified time
				yield return new WaitForSeconds (staminaRegenTick);
			} else { // if health >= 100, just yield 
				yield return null;
			}
		}
	}
	
	void FixedUpdate () {
		
		GetAxisData ();
		
		if (isGrounded) {
			if (vAxis > 0) {
				Drive (mainCam.transform.right);
			}
			if (vAxis < 0) {
				Drive (-mainCam.transform.right);
			}
			if (hAxis > 0) {
				Drive (-mainCam.transform.forward);
			}
			if (hAxis < 0) {
				Drive (mainCam.transform.forward);
			}
			if (zAxis > 0) {
				Drive (-mainCam.transform.up);
			}
			if (zAxis < 0) {
				Drive (mainCam.transform.up);
			}
			
		} else {
			if (vAxis > 0) {
				ApplyForce (mainCam.transform.forward);
			}
			if (vAxis < 0) {
				ApplyForce (-mainCam.transform.forward);
			}
			if (hAxis > 0) {
				ApplyForce (mainCam.transform.right);
			}
			if (hAxis < 0) {
				ApplyForce (-mainCam.transform.right);
			}
		}
		
	}
	private void Grapple()
	{
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 100)) {
			print ("Hit: " + hit.transform.name);
			grappleLine.SetPosition(0, player.position);
			grappleLine.SetPosition(1, hit.point);
			grapple = true;
			grappleLoc = hit.point;
			grappleDir = (hit.point - player.transform.position).normalized;
			pMan.stamina -= 50;
		}
		
	}
	private void GetAxisData()
	{
		hAxis = Input.GetAxis("Horizontal");
		vAxis = Input.GetAxis ("Vertical");
		zAxis = Input.GetAxis ("Spin");
	}
	
	private void Drive(Vector3 dir){
		if(player.velocity.magnitude < moveSpeed || dir.magnitude < player.velocity.magnitude)
		player.AddTorque (dir * moveSpeed * acelleration);
	}
	private void ApplyForce(Vector3 dir){
		player.AddForce (dir * airMoveDamp);
	}
	void OnCollisionStay(Collision other)
	{
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Rail") {
			isGrounded = true;
		}
	}
	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Rail") {
			isGrounded = false;
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Token") {
			pMan.stamina += 50;
		}
	}
	public Vector3 GrappleLoc()
	{
		return grappleLoc;
	}
	public void BoostJump()
	{
		jumpForce = jumpForceBoostPower;
	}
	
	public void BoostSpeed()
	{
		Debug.Log ("Speed Boosted");
		moveSpeed = speedBoost;

	}
	
}
