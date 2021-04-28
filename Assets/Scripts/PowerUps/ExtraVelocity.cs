using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraVelocity : MonoBehaviour
{
    public float mulVelocity = 2;

    PlayerController playerController;
    private float orVelocity;
    private void OnEnable()
    {
        playerController = GetComponent<PlayerController>();
        orVelocity = GetComponent<PlayerController>().vRun;

        GameManager.GetInstance().RefrescoAppears(true);

        //cuando se activa accedemos al float vRun del jugador y lo duplicamos
        GetComponent<PlayerController>().vRun = orVelocity * mulVelocity;
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
        GetComponent<PlayerController>().vRun = orVelocity;

        GameManager.GetInstance().RefrescoAppears(false);
    }
}


