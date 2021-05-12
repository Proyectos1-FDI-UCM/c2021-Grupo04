using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    HealthPlayer healthPlayer;
    
    private void OnEnable()
    {
        healthPlayer = GetComponent<HealthPlayer>();
        Debug.Log("vidas restantes "+healthPlayer.LivesRemaining());
        Debug.Log(healthPlayer.maxHealth);
        
        if (healthPlayer.LivesRemaining() < healthPlayer.maxHealth)
        {
            healthPlayer.AddLife();
            GameManager.GetInstance().AddOneHeartBySandwich();
        }
        Debug.Log("vidas after sandwich " + healthPlayer.LivesRemaining());

        DisableThis();
    }

    private void DisableThis()
    {
        this.enabled = false;
    }
}
