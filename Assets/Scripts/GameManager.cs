using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public bool gameOver;


	void Awake(){
		DontDestroyOnLoad (this.gameObject);

		if (instance == null) {
			instance = this;
		} 
		else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		gameOver = true;
	}

	// Update is called once per frame
	void Update () {

	}

	public void GameStart(){
		UiManager.instance.GameStart ();
	}

	public void GameOver(){
		gameOver = false;
		GameObject.Find ("Spawnerwithtime").GetComponent<Spawnerwithtime> ().StopSpawning();
		GameObject.Find ("BirdSpawner").GetComponent<BirdSpawner> ().StopBirdSpawn();
		ScoreManager.instance.StopScore ();
		LeaderBoardManager.instance.AddScoreToLeaderboard ();
		UiManager.instance.GameOver ();

	}
}
