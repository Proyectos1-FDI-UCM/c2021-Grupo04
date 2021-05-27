using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Áún sabiendo que es poco práctico, se va a consultar las vidas al GameManager
/// si estamos en la escena adecuada, asumiendo orden correcto en la build index
/// </summary>
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
        //Consultamos al GM las vidas que tenemos si estamos en la escena correcta
        health = maxHealth;
        color = GetComponentInChildren<ChangeColor>();
        //Sabemos que este método es poco eficaz, pero funciona, pretendemos cambiarlo en un futuro
        //Comprobamos la escena en la que estamos, y guardamos los datos
        if(GameManager.GetInstance().ActualSceneIndex() == 4)
        {
            health = GameManager.GetInstance().ActualSceneIndex();
        }

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

        if (health <= 0)
        {
            GameManager.GetInstance().ActivateGameOverPanel();          
        }


    }

    /// <summary>
    /// Cura toda la vida del jugador
    /// </summary>
    public void HealAllLife()
    {
        while(health < maxHealth)
        {
            health++;
            GameManager.GetInstance().AddOneHeartBySandwich();
        }
    }

    //Añade medio corazón
    public void AddLife()
    {
        health++;
        GameManager.GetInstance().AddOneHeartBySandwich();
    }

    public int LivesRemaining()
    {
        return health;
    }

    public void SaveLives()
    {
        if (GameManager.GetInstance().ActualSceneIndex() == 3)
        {
            GameManager.GetInstance().SaveLives(health);
        }
    }
}
   

