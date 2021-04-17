using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraVelocity : MonoBehaviour
{
    
    private void OnEnable()
    {
        GetComponent<PlayerController>().vRun = 8;
        Invoke("Tiempo", 10f);
    }
    void Tiempo()
    {
        this.enabled = false;

    }

    private void OnDisable()
    {
        GetComponent<PlayerController>().vRun = 4;
    }
}


