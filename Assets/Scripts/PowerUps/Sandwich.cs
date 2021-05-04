using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    HealthPlayer healthPlayer;
    private int lives;

    private void Start()
    {
        healthPlayer = GetComponent<HealthPlayer>();
       
    }
    private void OnEnable()
    {
        Debug.Log("vidas restantes "+healthPlayer.LivesRemaining());
        Debug.Log(healthPlayer.maxHealth);
        
        if (healthPlayer.LivesRemaining() <healthPlayer.maxHealth)
        {
            healthPlayer.AddLife();
            GameManager.GetInstance().AddOneHeartBySandwich();
        }
 
    }

    private void OnDisable()
    {
       
    }
}
