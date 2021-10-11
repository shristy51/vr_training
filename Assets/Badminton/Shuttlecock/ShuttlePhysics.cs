using UnityEngine;


public class ShuttlePhysics : MonoBehaviour
{

    public float t = 0.0f;



    void Update()
    {
        t += Time.deltaTime;
        if (t > 1.0) { t = 1.0f; }
        transform.position = (1.0f - t) * (1.0f - t) * transform.position + 2.0f * (1.0f - t) * t * new Vector3(1.0f,3.0f,0.0f) +
        (t * t) * new Vector3(3.0f,0.0f,0.0f);

    }

}