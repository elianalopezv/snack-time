using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour {

	public RectTransform playerIcon;
	public RectTransform snackIcon; 
	private float totalGameTime, speed;

	// Use this for initialization
	void Start () {

		totalGameTime = LevelManager.Instance.totalGameTime;
		StartCoroutine(MovePlayerToSnack());
		
	}
	
	private IEnumerator MovePlayerToSnack()
	{
		Vector2 currentPlayerPosition = playerIcon.localPosition;
		float time = 0f;
		while(time < 1f)
		{
			time += Time.deltaTime / totalGameTime;
			playerIcon.localPosition = Vector2.Lerp(currentPlayerPosition, snackIcon.localPosition, time);
			yield return null;
		}
	}
}
