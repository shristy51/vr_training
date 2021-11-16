using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacquetPhysics : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
	{
		GameObject shuttle = other.gameObject;
		//Debug.Log("Collision detected" + other.gameObject);
		if(shuttle.CompareTag("shuttle"))
		{
			
			Debug.Log("Destroying " + other.gameObject);
			
		}
	}
}
