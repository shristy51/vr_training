using UnityEngine;
using UnityEngine.XR;

public class ScoreScript : MonoBehaviour
{
    InputDevice m_InputDevice;
    XRNode controllerNode;
    public InputDevice inputDevice => m_InputDevice.isValid ? m_InputDevice : m_InputDevice = InputDevices.GetDeviceAtXRNode(controllerNode);
    bool OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
        if (inputDevice.TryGetHapticCapabilities(out var capabilities) &&
                capabilities.supportsImpulse)
        {
            return inputDevice.SendHapticImpulse(0u, 0.3f, 0.3f);
        }
        return false;
    }
}
