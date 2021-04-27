﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    /*Script asociado a los enemigos que detecta si la bola ha colisionado con el.
     * Para evitar errores a la hora de hacer daño a los enemigos, se pretende que la detección del
     * ataque solo sea posible cuando Makt Fange lanza la bola
     */
    // Start is called before the first frame update
    public int life = 30;
    public float impulseAfterDamageX = 0.2f;
    public float impulseAfterDamageY = 0.2f;

    private int health;
    Rigidbody2D rb;

    private void Start()
    {
        health = life;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(rb.velocity.x > 0)
        {
            Invoke("Stop", 0.2f);
        }
    }
    /// <summary>
    /// El enemigo sufre daño cuando la herropea colisiona con él
    /// este daño viene marcado por la variable damage
    /// </summary>
    /// <param name="damage">Daño actual que realiza le herropea</param>
    public void GetDamage(float damage)
    {
        health -= damage;
        rb.AddForce(new Vector2(impulseAfterDamageX, impulseAfterDamageY));
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    private void Stop ()
    { 
        rb.velocity = new Vector2(0, 0);
    }
}
