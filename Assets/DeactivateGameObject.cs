using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);   
    }

    void ActivatePressurePlate() {
        gameObject.SetActive(true);
    }
}
