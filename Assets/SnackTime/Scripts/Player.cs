using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 9f;
 	public float jumpSpeed = 20f;
 	public float gravity = 20f;
 	public float gravityForce = 3f; 
 	public float airTime = 2f;
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;
	private float jumpForce = 0;
 	private float invertGravity;
	private bool mouseUp = true;


	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update () {
		

		moveDirection *= speed;    
		if (controller.isGrounded && mouseUp) {
			// jumpForce is 0 if player grounded
			jumpForce = 0;
			// invertGravity is also reset based on the gravity
			invertGravity = gravity * airTime;

			if (Input.GetMouseButton(0)){
				// Jump! 
				jumpForce = jumpSpeed;
				mouseUp = false;
			}
		}

		// Jumping since jumpForce is not 0
		// we add invertGravity to our jumpForce and invertGravity is also
		// decreased so that we get a curvy jump
		if(Input.GetMouseButton(0) && jumpForce != 0){
			invertGravity -= Time.deltaTime;
			jumpForce += invertGravity * Time.deltaTime;
		} 
		// Here we apply the gravity
			jumpForce -= gravity*Time.deltaTime* gravityForce;
			moveDirection.y = jumpForce;
			controller.Move(moveDirection * Time.deltaTime);
		
		//Avoid holding click infinitely
		if(Input.GetMouseButtonUp(0))
		{
			mouseUp = true;
		}
		
	}

	void OnBecameInvisible()
	{
		LevelManager.Instance.LoseGame();
	}
}
