using UnityEngine;


public class MoveCurve : MonoBehaviour
{

    // Update is called once per frame
    public float t = 0.0f, velocity = 0.0f;
    public Vector3 curveTowards, endPoint;

    void Update()
    {
        t += velocity * Time.deltaTime;
        if (t > 1.0) { t = 1.0f; }
        transform.position = (1.0f - t) * (1.0f - t) * transform.position + 2 * (1.0f - t) * t * curveTowards + (t * t) * endPoint;

    }
}
