using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 4;
    public float inmunityCooldown = 1f;


    private float time = 0;
    private int health;
    Rigidbody2D rb;

    private void Start()
    {
       
        health = maxHealth;
        GameManager.GetInstance().ReDrawHearts(health);
        rb = GetComponent<Rigidbody2D>();
    } 

    public void LoseHearts(int damage)
    {       
        if (health > 0 && Time.time >= time + inmunityCooldown)
        {
            health -= damage;
            Debug.Log("Vidas restante del jugador " + health);
            time = Time.time;
            GameManager.GetInstance().HeartDestroyed();
        }

        else if (health <= 0)
        {
            GameManager.GetInstance().ExitGame();
            
        }

    }

  
   
}
