using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCurve : MonoBehaviour
{

    // Update is called once per frame
    public float t = 0.0f, velocity = 0.0f;
    public Vector3 P0, P1, P2;

    void Update()
    {
        t += velocity * Time.deltaTime;
        if (t > 1.0) { t = 1.0f; }
        transform.position = (1.0f - t) * (1.0f - t) * P0 + 2 * (1.0f - t) * t * P1 + (t * t) * P2;

    }
}
