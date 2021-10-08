using UnityEngine;


public class ScoreScript : MonoBehaviour
{
    public int gameScore = 0;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if (collision.gameObject.name == "Shuttlecock")
        {
            gameScore += 1;
        }
    }


}