using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFromAbove : MonoBehaviour {


	public AudioClip clip;

	public GameObject ExplosionGO;


	void Start () {
		
	}

	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D bam){

		if (bam.gameObject.tag == "Cowboy") {

			AudioSource.PlayClipAtPoint (clip,new Vector3 (-3.86f, 2.37f, -10f),0.5f);               

			Explosion ();

			Destroy (GameObject.FindWithTag("Bird"));

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
