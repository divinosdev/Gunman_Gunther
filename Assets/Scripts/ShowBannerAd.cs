using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBannerAd : MonoBehaviour {

	public static ShowBannerAd instance1; 

	void Awake(){
		DontDestroyOnLoad (this.gameObject);

		if (instance1 == null) {
			instance1 = this;
		} 
		else {
			Destroy (this.gameObject);
		}
	}

	void Start () {

		AdManager.instance.LoadBanner ();
	}
	

	void Update () {
		
	}
}
