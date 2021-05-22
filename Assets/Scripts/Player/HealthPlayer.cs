using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 8;
    public float inmunityCooldown = 1f;

    private float time = 0;
    private int health;
   
    Respawn spawn;
    ChangeColor color;


    private void Start()
    {
        spawn = GetComponent<Respawn>();
        health = maxHealth;
        color = GetComponent<ChangeColor>();
        Invoke("InstanceHearts", 0.1f);
       
    }
   
    public void InstanceHearts()
    {
        GameManager.GetInstance().ReDrawHearts(health);
       
    }
        
    
    public void LoseHearts(int damage)
    {       
        if (health > 0 && Time.time >= time + inmunityCooldown)
        {
            health -= damage;
            color.CambiaColor();
            Debug.Log("Vidas restante del jugador " + health);
            time = Time.time;
            for (int i = 0; i < damage; i++)
            {
                GameManager.GetInstance().HeartDestroyed();
            }
           
           
        }

        else if (health <= 0)
        {
            GameManager.GetInstance().ChargeMenu();
            
            

        }


    }
    public void AddLife()
    {
        health++;
    }
    public int LivesRemaining()
    {
        return health;
    }

    }
   

