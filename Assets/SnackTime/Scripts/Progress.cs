using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {

	public RectTransform playerIcon;
	public RectTransform snackIcon; 
	private float totalGameTime, speed;
	private Vector2 initialPlayerIconPos;

	// Use this for initialization
	void Start () {
		initialPlayerIconPos = playerIcon.localPosition;
		totalGameTime = LevelManager.Instance.totalGameTime;
		speed = Mathf.Abs(snackIcon.localPosition.x - playerIcon.localPosition.x) / totalGameTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
