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
            //Hacemos que el jugador guarde su vida en el GM
            collision.GetComponent<HealthPlayer>().SaveLives();
            Invoke("NextScene", 0.25f);
        }
    }

    private void NextScene()
    {
        GameManager.GetInstance().ChargeNextScene();
    }
}
