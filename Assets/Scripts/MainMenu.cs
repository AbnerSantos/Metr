using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	[SerializeField] GameObject credits;
	[SerializeField] GameObject options;
	[SerializeField] GameObject score;

	public AudioClip audioClip;
	public AudioSource audioSource;

	private enum scenes{
		mainMenu = 0,
		firstLevel = 1
		
	};

	private void Start(){
		credits.SetActive(false);		
		options.SetActive(false);		
		audioSource.Play();
	}

	public void PlayGame(){
		DontDestroyOnLoad(score);
		audioSource.Stop();
		SceneManager.LoadScene((int)scenes.firstLevel);
	}

	public void BackToMenu(){
		credits.SetActive(false);		
		options.SetActive(false);		
	}

	public void Rewind(){
		Destroy(GameObject.FindGameObjectWithTag("Score"));
		SceneManager.LoadScene(0);
	}

	public void Options(){
		options.SetActive(true);
	}
	public void Credits(){
		credits.SetActive(true);
	}
	
	public void Quit(){
		Application.Quit();
	}
}