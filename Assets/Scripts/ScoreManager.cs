using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;

	void Awake(){
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {

		bool scoreReward = PlayerPrefs.GetInt ("ScoreReward", 0) > 0;
		score = scoreReward ? PlayerPrefs.GetInt ("Score", 0) : 0;
		PlayerPrefs.SetInt( "Score", 0) ;
		PlayerPrefs.SetInt("ScoreReward", 0) ;
		//score = 0;
		//PlayerPrefs.SetInt ("Score", 0);
	}

	void Update () {

	}

	public void IncrementScore(){
		score++;
	}

	public void StopScore(){

		PlayerPrefs.SetInt ("Score", score);

		if (PlayerPrefs.HasKey ("HighScore")) {
			if (score > PlayerPrefs.GetInt ("HighScore")) {
				PlayerPrefs.SetInt ("HighScore", score);
			}
		} else {
			PlayerPrefs.SetInt ("HighScore", score);
		}

	}
}
