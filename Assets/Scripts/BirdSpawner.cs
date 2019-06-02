using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour {

	public GameObject Bird;    

	float[] randompos = new float[] { 1f, -1.5f};

	void Start () {

		StartBirdSpawn ();
	}

	void Update () {


	}

	public void StartBirdSpawn(){

		StartCoroutine("SpawnObj");


	}

	public void StopBirdSpawn() {

		StopCoroutine("SpawnObj");
	
	
	}


	IEnumerator SpawnObj()
	{
		Instantiate(Bird, new Vector3(transform.position.x,transform.position.y*randompos[Random.Range(0,randompos.Length)]), Quaternion.identity);

		yield return new WaitForSeconds(Random.Range(1.5f, 2f));
			
		StartCoroutine("SpawnObj");

			}
			
}