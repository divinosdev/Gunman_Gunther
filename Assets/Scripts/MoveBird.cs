using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBird : MonoBehaviour {

	public AudioClip clip;
	[SerializeField]
	private float BirdSpeed;
	[SerializeField]
	private float updownSpeed;
	Rigidbody2D rb;
	public GameObject ExplosionGO;


	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
		Movebird ();
		InvokeRepeating ("SwitchUpDown", 0.1f, 0.7f);

	}

	void Movebird() {
		
			rb.velocity = new Vector2 (-BirdSpeed, updownSpeed);
	}


	void SwitchUpDown(){
		updownSpeed = -updownSpeed;
		rb.velocity = new Vector2 (BirdSpeed, updownSpeed);
	}




	public void OnTriggerEnter2D(Collider2D bam){

		if (bam.gameObject.tag == "Bullet") {

			AudioSource.PlayClipAtPoint (clip,new Vector3 (-3.86f, 2.37f, -10f),0.5f);               

			Explosion ();
		
			Destroy (gameObject);
		
		} 
		else if (bam.gameObject.tag == "Remover") {

			Destroy (gameObject);
			} 

	}


	void Explosion(){
		GameObject explosion = (GameObject)Instantiate(ExplosionGO);

		explosion.transform.position = transform.position;
	
	}
}
