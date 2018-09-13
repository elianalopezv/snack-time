using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	public Transform obstaclesParent;
	public List<Transform> obstacles;


	public void GenerateObstacle(Transform block)
	{
		Instantiate(obstacles[Random.Range(0, obstacles.Count)],
			GetRandomPositionInBlock(block),
			Quaternion.Euler(Vector2.zero), obstaclesParent);

		DeleteUselessObstacles();
	}

	private Vector3 GetRandomPositionInBlock(Transform block)
	{
		float x = block.position.x;
		float y = block.position.y + 1;
		float z = Mathf.RoundToInt(Random.Range(block.position.z - block.localScale.z, block.position.z + block.localScale.z));

		return new Vector3(x,y,z);
	}

	private void DeleteUselessObstacles()
	{
		int obstaclesInScene = BlockManager.Instance.totalBlocksScreen;
		
		if(obstaclesParent.childCount > obstaclesInScene)
		{
			Destroy(obstaclesParent.GetChild(0).gameObject);
		}
	}
}
