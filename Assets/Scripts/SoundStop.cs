using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStop : MonoBehaviour {
	
	public int check;

	void Awake(){
	
		check = PlayerPrefs.GetInt("Sound");

			if (check == 0)
			{
			AudioListener.pause = true;
			}
		else if (check == 1)
			{
			AudioListener.pause = false;
			}
	
	}

	void Start () {

		
		}
		

	

	void Update () {
		
	}

	public void Soundstop() {
		PlayerPrefs.SetInt ("Sound", 0);
	
		AudioListener.pause = true;
	
	}

	public void Soundstart(){
		PlayerPrefs.SetInt ("Sound", 1);

		AudioListener.pause = false;
	
	}
}
