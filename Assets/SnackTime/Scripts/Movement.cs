using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private BlockManager manager;

	// Use this for initialization
	void Start () {
		manager = BlockManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(-Vector3.forward * manager.blocksSpeed * Time.deltaTime);
	}
}
