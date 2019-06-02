using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour {

	public float scrollSpeed;
	[SerializeField]
	private float j;


	void Start () {
	}
	

	void Update () {
		
		if (!GameObject.Find ("CowBoy").GetComponent<Cowboy> ().gameOver && GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().score <= 100) {
			Vector2 offset = new Vector2 (Time.time * scrollSpeed, 0);
			GetComponent<Renderer> ().material.mainTextureOffset = offset; 
		} 
		else if (!GameObject.Find ("CowBoy").GetComponent<Cowboy> ().gameOver && GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().score > 100) {

			Vector2 offset = new Vector2 (Time.time * j * scrollSpeed, 0);
			GetComponent<Renderer> ().material.mainTextureOffset = offset;
		
		} 
			
	}

}

