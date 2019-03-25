using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class EventTest : MonoBehaviour {

      void OnEnable ()
    {
        EventManager.StartListening ("Light", TurnOnLights);
    }

    void OnDisable ()
    {
        EventManager.StopListening ("Light", TurnOnLights);
    }

    void TurnOnLights ()
    {
        Debug.Log ("The lights turned on");
    }
}