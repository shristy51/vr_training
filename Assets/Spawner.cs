using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject mPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());  
    }

    IEnumerator Spawn() {
        while (true)
        {

            GameObject.Instantiate(mPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
