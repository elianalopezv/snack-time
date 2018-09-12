using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float jumpSpeed;
	public float gravity;
	private CharacterController controller;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetMouseButton(0) && controller.isGrounded)
		{
			moveDirection.y = jumpSpeed;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
