using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	public Transform blockPrefab;
	public Transform player;
	public float blocksSpeed = 15f;

	private int blocksInScreen;
	private int totalBlocks;
	private List<Transform> blocksList = new List<Transform>();

	// Use this for initialization
	void Start () {
		
		totalBlocks = transform.childCount;
		blocksInScreen = totalBlocks - 2;
		
		for(int i = 0; i < totalBlocks; i++)
			blocksList.Add(transform.GetChild(i));


	}
	
	// Update is called once per frame
	void Update () {
		
		if(LimitDistanceReached())
		{
			SendBlockToEnd();
		}
	}

	private bool LimitDistanceReached()
	{
		return ((blocksInScreen - 1) * blockPrefab.localScale.z) >
			(Mathf.Abs(player.position.z - blocksList[blocksList.Count - 1].position.z));
	}

	private void SendBlockToEnd()
	{
		Transform blockToSend = blocksList[0];
		Transform lastBlock = blocksList[blocksList.Count - 1];
		blocksList.RemoveAt(0);

		blockToSend.transform.position = new Vector3(blockToSend.position.x,
			blockToSend.position.y, 
			lastBlock.position.z + (blockToSend.localScale.z - Time.deltaTime * blocksSpeed));

		blocksList.Add(blockToSend);
	}
}
