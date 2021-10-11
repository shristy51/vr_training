using UnityEngine;


public class ShuttlePhysics : MonoBehaviour
{

    public float t = 0.0f, velocity = 0.0f;
    public Vector3 curvePoint;
    public GameObject Obj1;

    void Update()
    {
        t += velocity * Time.deltaTime;
        if (t > 1.0) { t = 1.0f; }
        transform.position = (1.0f - t) * (1.0f - t) * transform.position + 2 * (1.0f - t) * t * curvePoint +
        (t * t) * Obj1.transform.position;

    }

}