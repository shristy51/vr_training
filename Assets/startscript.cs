using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startscript : MonoBehaviour
{
	public GameObject go1;
	public GameObject go2;
	
	
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(start_delay());
    }

    // Update is called once per frame
 public IEnumerator start_delay()
	{
		Debug.Log("delaydelay " + Time.time);
		yield return new WaitForSeconds(7);
		go1.SetActive(true);
		go2.SetActive(true);
		
	}
}
