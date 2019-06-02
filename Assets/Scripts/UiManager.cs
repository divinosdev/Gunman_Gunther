using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour {

	public static UiManager instance;
	public Text scoreText;
	public Text EndScore;
	public Text highScoreText;
	public GameObject Panel;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		
	}

	void Update () {

		scoreText.text = ScoreManager.instance.score.ToString ();
		
	}
	public void GameStart(){

		Panel.SetActive (false);
	
	}

	public void GameOver(){
		highScoreText.text = "Top : " + PlayerPrefs.GetInt ("HighScore");
		EndScore.text = "Score : " + PlayerPrefs.GetInt ("Score");

		Panel.SetActive (true);
	}


	public void Restart(){

		SceneManager.LoadScene ("Game");
	}

	public void Menu(){
	    

		SceneManager.LoadScene ("Menu");
	}


}
