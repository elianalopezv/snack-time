using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour {

	void OnBecameInvisible()
	{
        Debug.Log("juancho");

        LevelManager.Instance.LoseGame();
	}
}
