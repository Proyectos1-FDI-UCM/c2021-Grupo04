using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private float posicionColchonX, posicionColchonY;
    public bool respawn;
    int lives;
    void Start()
    {
        if (respawn)
        {
            Spawn();
        }
        
    }

    void Update()
    {
        
    }
    public void Llegado(float x, float y)
    {
        PlayerPrefs.SetFloat("posicionColchonX", x);
        PlayerPrefs.SetFloat("posicionColchonY", y);
    }

    public void Spawn()
    {
        if (PlayerPrefs.GetFloat("posicionColchonX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("posicionColchonX"), PlayerPrefs.GetFloat("posicionColchonY"));
        }
    }
}

