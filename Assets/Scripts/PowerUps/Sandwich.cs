using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    //Miguel y Adrián
    HealthPlayer healthPlayer;
    public int lives = 2;

    
    private void OnEnable()
    {
        healthPlayer = GetComponent<HealthPlayer>();
        Debug.Log("vidas restantes "+healthPlayer.LivesRemaining());
        Debug.Log(healthPlayer.maxHealth);
        for (int i = 0; i < lives; i++)
        {
            if (healthPlayer.LivesRemaining() < healthPlayer.maxHealth)
            {
                healthPlayer.AddLife();
                GameManager.GetInstance().AddOneHeartBySandwich();
            }
        }
        Debug.Log("vidas tras curarte"+healthPlayer.LivesRemaining());
        DisableSandwich();
    }

      public void DisableSandwich()
      {
        this.enabled = false;
      } 
}
