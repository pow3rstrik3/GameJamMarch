using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Valve.VR.InteractionSystem;

public class ActivatePressurePlate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);   
    }

    private void OnTriggerEnter(Collider other)
    {
//        if (other.CompareTag("Player"))
//        {
            transform.position = new Vector3( transform.position.x ,transform.position.y - 0.05f, transform.position.z);
//        }
    }

    private void OnTriggerExit(Collider other)
    {
//        if (other.CompareTag("Player"))
//        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z);
//        }
    }

    public void ActivatePressurePlateFunction() {
        gameObject.SetActive(true);
    }
}
