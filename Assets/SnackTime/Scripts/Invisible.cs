using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Invisible : MonoBehaviour {

	void OnBecameInvisible()
	{
		LevelManager.Instance.LoseGame();
	}
}
