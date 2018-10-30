using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

	AudioSource audioSource;
	

	void Awake()
	{
		Application.targetFrameRate = 180;
	}
	public void StartGame()
	{
		Time.timeScale = 1;
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		float duration = audioSource.clip.length - 0.7f;
		StartCoroutine(WaitForSound(duration));
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	private IEnumerator WaitForSound(float duration)
	{
		yield return new WaitForSeconds(duration);
		SceneManager.LoadScene(1);
	}
}
