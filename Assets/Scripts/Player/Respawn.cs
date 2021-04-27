using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private float posicionColchonX, posicionColchonY;
    void Start()
    {
        if (PlayerPrefs.GetFloat("posicionColchonX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("posicionColchonX"), PlayerPrefs.GetFloat("posicionColchonY"));
        }
    }

    public void Llegado(float x, float y)
    {
        PlayerPrefs.SetFloat("posicionColchonX", x);
        PlayerPrefs.SetFloat("posicionColchonY", y);
    }
}

