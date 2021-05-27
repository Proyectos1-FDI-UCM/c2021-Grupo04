using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    //Adrián,Miguel 
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
        color = GetComponentInChildren<ChangeColor>();
        Invoke("InstanceHearts", 0.1f);
       
    }
   
    public void InstanceHearts()
    {
        GameManager.GetInstance().ReDrawHearts(health);
       
    }
        
//Metodo para restar vidas    
    public void LoseHearts(int damage)
    {       
        //metemos un cooldown de inmunidad
        if (health > 0 && Time.time >= time + inmunityCooldown)
        {
            //restamos la referencia damage (editable desde el inspector) a las vidas
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
            GameManager.GetInstance().ActivateGameOverPanel();
            
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
   

