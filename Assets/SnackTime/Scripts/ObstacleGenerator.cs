﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

	public Transform obstaclesParent;
	public List<Transform> obstacles;


	public void GenerateObstacle(Transform block)
	{
		Instantiate(obstacles[Random.Range(0, obstacles.Count)],
			GetRandomPsitionInBlock(block),
			Quaternion.Euler(Vector2.zero), obstaclesParent);
	}

	private Vector3 GetRandomPsitionInBlock(Transform block)
	{
		float x = block.position.x;
		float y = block.position.y + 1;
		float z = Random.Range(block.position.z - block.localScale.z, block.position.z + block.localScale.z);

		return new Vector3(x,y,z);
	}
}
