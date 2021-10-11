using UnityEngine;


public class ScoreScript : MonoBehaviour
{
    public int score;
    public void OnTriggerEnter(Collider other)
    {
        score += 1;
    }

}