using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacquetPhysics : MonoBehaviour
{
	static int score_counter=-1;
	public List<GameObject> Score = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
	{
		GameObject shuttle = other.gameObject;
		
		//	Debug.Log("Collision detected" + other.gameObject);
		if(shuttle.CompareTag("shuttle"))
		{
			score_counter++;
			//Score[score_counter]
			Debug.Log("Destroying " + other.gameObject);
			
		}
	}
}
