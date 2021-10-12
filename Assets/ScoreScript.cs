using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreScript : MonoBehaviour
{
    [SerializeField]
    XRBaseController controller;
    bool hit_bool = false;
    bool OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
        hit_bool = true;
        return hit_bool;
    }
    protected void Start()
    {
        if (controller == null)
            Debug.LogWarning("Reference to the Controller is not set in the Inspector window, this behavior will not be able to send haptics. Drag a reference to the controller that you want to send haptics to.", this);
     
        StartCoroutine(StartPeriodicHaptics());
    }
     
    IEnumerator StartPeriodicHaptics()
    {
        // Trigger haptics every second
        var delay = new WaitForSeconds(1f);
     
        while (true)
        {
            yield return delay;
            SendHaptics();
            hit_bool = false;
        }
    }
     
    void SendHaptics()
    {
        if (controller != null && hit_bool == true)
            controller.SendHapticImpulse(0.7f, 0.1f);
    }
        
}
