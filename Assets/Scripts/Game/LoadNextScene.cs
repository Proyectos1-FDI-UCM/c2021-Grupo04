using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextScene : MonoBehaviour
{
    //Miguel

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pasa a la siguiente escena si el jugador entra
        if(collision.GetComponent<PlayerController>() != null)
        {
            GameManager.GetInstance().ChargeNextScene();
        }
    }
}
