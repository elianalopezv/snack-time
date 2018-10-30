using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float totalGameTime;

	[Header("Sounds")]
	public AudioSource backgroundMusic;
	public AudioSource endMusic;

	[Header("Canvas")]
	public Transform endPanel;
	public Transform winPanel;
	public Transform losePanel;

	public static LevelManager Instance;


	void Awake()
	{
		Instance = this;
		Time.timeScale = 1;
		Application.targetFrameRate = 180;
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
		endPanel.gameObject.SetActive(true);
		winPanel.gameObject.SetActive(true);
	}

	public void LoseGame()
	{
		backgroundMusic.Stop();
		endMusic.Play();
		StopGame();
		endPanel.gameObject.SetActive(true);
		losePanel.gameObject.SetActive(true);
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
