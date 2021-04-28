using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int lives = 8;
    public float inmunityCooldown = 1f;

    private float time = 0;
    private int health;
    Respawn spawn;

    private void Start()
    {
        spawn = GetComponent<Respawn>();
        health = lives;
    } 

    public void LoseHearts(int damage)
    {       
        if (health > 0 && Time.time >= time + inmunityCooldown)
        {
            health -= damage;
            Debug.Log("Vidas restante del jugador " + health);
            time = Time.time;
        }

        if (health <= 0)
        {           
            spawn.Spawn();
            health = lives;
        }
    }
}
