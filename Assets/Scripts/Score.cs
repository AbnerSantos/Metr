using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour {
	[SerializeField] float startTime;
	[SerializeField] float endTime;
	[SerializeField] int time = 0;
	[SerializeField] int multiplier;
	[SerializeField] int score;
	[SerializeField] bool repeating = false;
	[SerializeField] Travel underground;
	[SerializeField] TextMeshProUGUI scoreText;
	AudioSource audioS;

	void Awake()
	{
		audioS = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
		audioS.Play();
	}
	void ScoreCounter(){
		repeating = true;
		time++;
		if(SceneManager.GetActiveScene().buildIndex != 1){
			CancelInvoke();
		}
	}

	void Update () {
		if(SceneManager.GetActiveScene().buildIndex == 1){
			if(underground == null)
				underground = GameObject.FindGameObjectWithTag("Underground").GetComponent<Travel>();
			if(!repeating) // 1 = PlayGame Scene
				InvokeRepeating("ScoreCounter", 0f, 1f);
		} else if(SceneManager.GetActiveScene().buildIndex == 2){
			score = time * multiplier;
			scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<TextMeshProUGUI>();
			scoreText.text = score.ToString();
		}
		
	}
}
