using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour {


	void Awake()
	{
		Time.timeScale = 1f;
	}

	public void GoToHome()
	{
		SceneManager.LoadScene(0);
	}
}
