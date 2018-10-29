using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float totalGameTime;
	public AudioSource backgroundMusic;
	public AudioSource endMusic;

	public static LevelManager Instance;


	void Awake()
	{
		Instance = this;
		Time.timeScale = 1;
		Application.targetFrameRate = 120;
	}
	void Update()
	{
		totalGameTime -= Time.deltaTime;
		if(totalGameTime < 0)
		{
			WinGame();
		}
	}

	public void WinGame()
	{
		StopGame();
		backgroundMusic.Stop();
		endMusic.Play();
		Transform endPanel = CanvasManager.Instance.transform.Find("EndPanel");
		endPanel.gameObject.SetActive(true);
	}

	public void LoseGame()
	{
		backgroundMusic.Stop();
		endMusic.Play();
		StopGame();
		Transform endPanel = CanvasManager.Instance.transform.Find("EndPanel");
		endPanel.gameObject.SetActive(true);
	}

	public void StopGame()
	{
		Time.timeScale = 0;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void GoToHome()
	{
		SceneManager.LoadScene(0);
	}
}
