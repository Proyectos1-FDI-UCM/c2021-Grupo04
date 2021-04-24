using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraVelocity : MonoBehaviour
{
    
    private void OnEnable()
    {
        //cuando se activa accedemos al float vRun del jugador y lo duplicamos
        GetComponent<PlayerController>().vRun = 8;
        //invocamos durante 10 secs
        Invoke("Tiempo", 10f);
    }
    void Tiempo()
    {
        this.enabled = false;

    }

    private void OnDisable()
    {
        //al desactivarse restablecemos el valor de vRun
        GetComponent<PlayerController>().vRun = 4;
    }
}


