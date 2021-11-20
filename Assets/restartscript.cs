using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartscript : MonoBehaviour
{

    public void Start() {
		Debug.Log("Inside restart script");
          SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);	
 
	
	}
}
