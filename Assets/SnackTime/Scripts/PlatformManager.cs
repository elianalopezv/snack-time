using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	public Transform platformPrefab;
	public Transform player;
	public float platformsSpeed = 15f;

	private int platformsInScreen;
	private int totalPlatforms;
	private List<Transform> platformsList = new List<Transform>();
	private bool changeDone = true;

	// Use this for initialization
	void Start () {
		
		totalPlatforms = transform.childCount;
		platformsInScreen = totalPlatforms - 2;
		
		for(int i = 0; i < totalPlatforms; i++)
			platformsList.Add(transform.GetChild(i));


	}
	
	// Update is called once per frame
	void Update () {
		
		if(LimitDistanceReached() && changeDone)
		{
			SendPlatformToEnd();
		}
	}

	private bool LimitDistanceReached()
	{
		return (platformsInScreen * platformPrefab.localScale.z) >
			(Mathf.Abs(player.position.z - platformsList[platformsList.Count - 1].position.z));
	}

	private void SendPlatformToEnd()
	{
		Transform platformToSend = platformsList[0];
		Transform lastPlatform = platformsList[platformsList.Count - 1];
		platformsList.RemoveAt(0);

		platformToSend.transform.position = new Vector3(platformToSend.position.x,
			platformToSend.position.y, 
			lastPlatform.position.z + (platformToSend.localScale.z - Time.deltaTime * platformsSpeed));

		platformsList.Add(platformToSend);
	}
}
