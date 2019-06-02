using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour {

	AudioSource jumpsound;
	AudioSource gameoversound;
	private Rigidbody2D rb;
	[SerializeField]
	private float power = 200f;
	public bool jump;
	private Animator anim;
	public bool gameOver = true;


	void Start () {
		
		AudioSource[] audios = GetComponents<AudioSource> ();
		jumpsound = audios [0];


		rb = GetComponent<Rigidbody2D> ();	

		jump = true;

		anim = GetComponent<Animator> ();
	}



	public void Update () {

	//if (Input.GetKey(KeyCode.Space))

		if (Input.GetMouseButton (0) && Input.mousePosition.x < Screen.width / 2) 
		 {	

			if (gameOver == false && jump) 
				{
				
				jumpsound.Play ();

					rb.velocity = Vector2.zero;
				    rb.velocity = new Vector2 (0, power);
					anim.SetTrigger ("Jump");

				}

			} else if (gameOver == true) {
			
				jump = false;

			}

	}
		

	void OnCollisionEnter2D(Collision2D col){
	
		if (col.gameObject.tag == "Ground") {
		
			jump = true;
		
		}
	}


	void OnCollisionExit2D(Collision2D col2){
		if (col2.gameObject.tag == "Ground") {
		
			jump = false;

		} else if (col2.gameObject.tag == "Obstacle") {
			
			gameOver = true;
			GameManager.instance.GameOver ();
			anim.SetTrigger ("Die");
		
		}
	
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Bird")
		{		
			gameOver = true;
			GameManager.instance.GameOver ();
			anim.SetTrigger ("Die");

	}
		else if (col.gameObject.tag == "ScoreChecker") {
		


			ScoreManager.instance.IncrementScore ();
		}
	
	}
	

}


	
	
	





			

		

