using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playScript : MonoBehaviour
{   public GameObject sc1;
    public GameObject uiCanvas;
	
    public void OnButton()
	{
		sc1.SetActive(true);	
		uiCanvas.SetActive(false);
	}
}
