using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacquetPhysics : MonoBehaviour
{
	int score_counter=-1;

	public List<GameObject> Score = new List<GameObject>();
	public GameObject scorecard;
    private void OnTriggerEnter(Collider other)
	{
		GameObject shuttle = other.gameObject;
		
		//	Debug.Log("Collision detected" + other.gameObject);
		if(shuttle.CompareTag("shuttle"))
		{
			score_counter++;
			//Score[score_counter]
		    Score[score_counter].GetComponent<Renderer>().material.color = Color.green;
			Debug.Log("Destroying " + other.gameObject);
			
		}
	}
}
