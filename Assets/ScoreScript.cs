using UnityEngine;


public class ScoreScript : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
    }

}
