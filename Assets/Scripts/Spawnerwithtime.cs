using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnerwithtime : MonoBehaviour {

	[SerializeField]
	public GameObject Cactus;
	public GameObject Stone;
	public GameObject Barrel;
	public GameObject Stump;
	private int i;

	private bool shouldSpawn = false;

	void Start () {

		StartSpawn ();
	}

	void Update () {


	}


public void StartSpawn(){
		shouldSpawn = true;
		StartCoroutine(SpawnObj());


}

public void StopSpawning() {

		shouldSpawn = false;


}


public IEnumerator SpawnObj()
	{   while (shouldSpawn) {
			
			int i = Random.Range (1, 5);
			GameObject obj;
			if (i == 1) {
				obj = Cactus;
			} else if (i == 2) {
				obj = Stone;
			} else if (i == 3) {
				obj = Barrel;
			} else if (i == 4) {
				obj = Stump;
			} else {
				obj = Stump;
			}
			Instantiate (obj, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);



			yield return new WaitForSeconds (Random.Range (1f, 1.5f));
		}

}

}
