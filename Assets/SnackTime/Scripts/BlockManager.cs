using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

	public Transform blockPrefab;
	public Transform player;
	public float blocksSpeed;

	private int totalBlocksScreen = 5;
	private int totalBlocks;
	private List<Transform> blocksInScreen = new List<Transform>();
	private List<Transform> blocksInPool = new List<Transform>();
	private float poolYPosition = -10f, sceneYPosition = -1.5f;


	// Use this for initialization
	void Start () {
		
		totalBlocks = transform.childCount;
		
		for(int i = 0; i < totalBlocksScreen; i++)
		{
			blocksInScreen.Add(transform.GetChild(i));
		}
		
		for(int i = totalBlocksScreen; i < totalBlocks; i++)
		{
			Transform block = transform.GetChild(i);
			blocksInPool.Add(block);
			block.localPosition = new Vector3(block.localPosition.x, poolYPosition, block.localPosition.z);
		}


	}
	
	// Update is called once per frame
	void Update () {
		
		if(LimitDistanceReached())
		{
			ExchangeBlocks();
			
		}
	}

	private bool LimitDistanceReached()
	{
		return ((totalBlocksScreen - 3) * blockPrefab.localScale.z) >
			(Mathf.Abs(player.position.z - blocksInScreen[blocksInScreen.Count - 1].position.z));
	}

	private void ExchangeBlocks()
	{
		Transform blockToSend = blocksInScreen[0];
		Transform lastBlock = blocksInScreen[blocksInScreen.Count - 1];
		blocksInScreen.RemoveAt(0);
		SendBlockToPool(blockToSend);
		Transform newBlock = GetBlockFromThePool();

		newBlock.transform.position = new Vector3(lastBlock.position.x,
			sceneYPosition, 
			lastBlock.position.z + (lastBlock.localScale.z - Time.deltaTime * blocksSpeed));

		blocksInScreen.Add(newBlock);
	}

	private void SendBlockToPool(Transform block)
	{
		block.transform.position = new Vector3(block.transform.localPosition.x, poolYPosition, block.transform.localPosition.z);
		blocksInPool.Add(block);
	}

	private Transform GetBlockFromThePool()
	{
		int index = Random.Range(0,blocksInPool.Count);
		Transform block = blocksInPool[index];
		blocksInPool.RemoveAt(index);
		return block;
	}


}
