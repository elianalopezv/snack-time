using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private PlatformManager manager;
	// Use this for initialization
	void Start () {
		
		manager = GetComponentInParent<PlatformManager>();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(-Vector3.forward * manager.platformsSpeed * Time.deltaTime);
	}
}
