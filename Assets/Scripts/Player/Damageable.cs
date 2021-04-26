using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Si lo que colisiona con Makt Fange posee el script bullet
        if (other.GetComponent<Bullet>() != null)
        {
            GameManager.GetInstance().LoseHearts();
            Debug.Log("Pierdo vida");
        }

    }
}
