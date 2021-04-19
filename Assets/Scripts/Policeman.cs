using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{

    
    public GameObject Player;
    
    void Update()
    {
        if (Player.transform.position.x < transform.position.x)
        {
            transform.right = Vector2.left;
        }
        if (Player.transform.position.x > transform.position.x)
        {
            transform.right = Vector2.right;
        }
    }
}
        

