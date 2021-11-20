using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateExitRestart : MonoBehaviour
{
    public GameObject sc1;
	
    public void OnButton()
	{
		sc1.SetActive(true);
	}
}
