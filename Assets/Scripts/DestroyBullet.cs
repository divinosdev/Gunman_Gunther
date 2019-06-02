using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D bam)
	{
		if (bam.tag =="Bird"||bam.tag=="BirdChecker") 
		{   
			ScoreManager.instance.IncrementScore ();
			Destroy(gameObject);
		}
		else if (bam.tag=="Bullet Remover")
			{
				Destroy(gameObject);

		}
	
	}  

}
	
