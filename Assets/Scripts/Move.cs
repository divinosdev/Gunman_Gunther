using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	private float speed = 11.25f;
	private float i= 1.2f;

	void Start () {
		
	}
	

	void Update () {


		if (!GameObject.Find ("CowBoy").GetComponent<Cowboy> ().gameOver && GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().score <= 100) {

			transform.Translate (Time.deltaTime * -speed, 0, 0);
		} 

		else if (!GameObject.Find ("CowBoy").GetComponent<Cowboy> ().gameOver && GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ().score > 100 )
			{
		
			transform.Translate (Time.deltaTime * i * -speed, 0, 0);
		}
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Remover") {
			Destroy (gameObject);
		}
	
	}

}


