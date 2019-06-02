using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	AudioSource shootsound;
	public GameObject projectile;
	public Vector2 velocity;
	bool canShoot= true;
	public Vector2 offset = new Vector2(0.4f,0.1f);
	public float cooldown;


	void Start () {
		AudioSource[] audios = GetComponents<AudioSource> ();
		shootsound = audios [1];

	}
		

	public void Update () {

		if  (Input.GetMouseButton (0) && Input.mousePosition.x > Screen.width/2) {



			if (canShoot&& !GameObject.Find ("CowBoy").GetComponent<Cowboy> ().gameOver) {
			
				shootsound.Play ();
				GameObject go = (GameObject)

			Instantiate (projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
				go.GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocity.x * transform.localScale.x, velocity.y);

				GetComponent<Animator> ().SetTrigger ("Shoot");

				StartCoroutine (CanShoot ());
			}
		}


	}


	IEnumerator CanShoot()
	{
		canShoot = false;
		yield return new WaitForSeconds (cooldown);
		canShoot = true;

		}



	void OnCollisionExit2D(Collision2D col2){
		
		if (col2.gameObject.tag == "Obstacle") {

			canShoot = false;

		}

	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Bird")
		{	

			canShoot = false;
	}
	
	}
}

