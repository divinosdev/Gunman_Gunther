using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowRewardAd : MonoBehaviour {

	public static ShowRewardAd instance;



	// Use this for initialization
	void Start () {

		if (!GameObject.Find ("AdManager").GetComponent<AdManager> ().rewardBasedVideo.IsLoaded ()) {
			gameObject.SetActive (false);
		}
	
	}
			

	
	void Update () {


		}



	public void OnClickRewardButton(){


		GameObject.Find("AdManager").GetComponent<AdManager>().rewardBasedVideo.Show();
	}
}
