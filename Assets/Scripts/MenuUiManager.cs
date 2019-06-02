using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUiManager : MonoBehaviour {

	public Text topscore;
	public Text Rank;
	void Start () {
		
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
		
		topscore.text = "Top : " + PlayerPrefs.GetInt ("HighScore");
		if (PlayerPrefs.GetInt ("HighScore") <= 100) {

			Rank.text = "Rank : Noob";
		} else {
			Rank.text = "Rank : Cowboy";
		}
	}


	public void Play(){
		SceneManager.LoadScene ("Game");

	}

	public void Exit(){

		Application.Quit();
	
	}

}
