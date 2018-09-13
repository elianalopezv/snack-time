using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public float totalGameTime;
	public static LevelManager Instance;


	void Awake()
	{
		Instance = this;
		Time.timeScale = 1;
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
		Transform endPanel = CanvasManager.Instance.transform.Find("EndPanel");
		endPanel.Find("MessageText").GetComponent<Text>().text = "YOU WIN!";
		endPanel.gameObject.SetActive(true);
	}

	public void LoseGame()
	{
		StopGame();
		Transform endPanel = CanvasManager.Instance.transform.Find("EndPanel");
		endPanel.Find("MessageText").GetComponent<Text>().text = "YOU LOSE!";
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
