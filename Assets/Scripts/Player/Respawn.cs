using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    //Eduardo y Miguel
    public bool respawn=true;
    private float posicionColchonX, posicionColchonY;
    
    private HealthPlayer vidas;
    void Start()
    {
        vidas = GetComponent<HealthPlayer>();
        if (respawn)
        {
            Spawn();
        }
       
    }


    public void Llegado(float x, float y)
    {
        PlayerPrefs.SetFloat("posicionColchonX", x);
        PlayerPrefs.SetFloat("posicionColchonY", y);
        SaveScene();
    }

    public void Spawn()
    {
        //Si el jugador ha pasado por un colchón (no pone los colchones en x = 0)
        if (PlayerPrefs.GetFloat("posicionColchonX") != 0)
        {
            //Si la escena es la misma que la del último colchón visitado, se carga la posición
            if(PlayerPrefs.GetInt("ActiveScene") == SceneManager.GetActiveScene().buildIndex)
            {
                transform.position = new Vector2(PlayerPrefs.GetFloat("posicionColchonX"), PlayerPrefs.GetFloat("posicionColchonY"));
                Invoke("HealPlayer", 1.2f);
            }
            //Si es otra escena, borra las coordenadas
            else
            {
                PlayerPrefs.DeleteKey("posicionColchonX");
                PlayerPrefs.DeleteKey("posicionColchonY");
            }
        }
    }

    private void HealPlayer()
    {
        vidas.HealAllLife();
    }

    public void SaveScene()
    {
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("ActiveScene", activeScene);
    }
}

