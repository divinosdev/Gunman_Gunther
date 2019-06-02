using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class LeaderBoardManager : MonoBehaviour {

	public static LeaderBoardManager instance;



	void Awake(){

		if (instance == null) {
			instance = this;
		} 

	}



	void Start () {

		PlayGamesPlatform.Activate ();
		Login ();
	}


	void Update () {

	}

	public void Login(){

		Social.localUser.Authenticate ((bool success) => {
		});

	}

	public void AddScoreToLeaderboard(){
	
		Social.ReportScore (ScoreManager.instance.score, LeaderBoard.leaderboard_top_gunmen, (bool success) => {


		});


	
	}


	public void ShowLeaderboard(){

		if (Social.localUser.authenticated) {
			PlayGamesPlatform.Instance.ShowLeaderboardUI (LeaderBoard.leaderboard_top_gunmen);
		} else {

			Login ();
		}
	}
}



