using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{

    
    public GameObject Player;
    
    void Update()
    {
        //dependiendo de la posición del jugador respecto al policía, este último girará su transform right a derecha o izquierda
        if (Player.transform.position.x < transform.position.x)
        {
            transform.right = Vector2.left;
        }
        else
        {
            transform.right = Vector2.right;
        }
    }
}
        

