using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoADistancia : MonoBehaviour
{
    public int damage;
    public float distanciaAtaque;
    private float distancia;
    GameObject objetivo;
    HealthPlayer player;

    void Update()
    {
        distancia = Vector2.Distance(transform.position, objetivo.transform.position);

        if (distanciaAtaque >= distancia)
        {
            if (player != null)
            {
                player.LoseHearts(damage);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            objetivo = collision.gameObject;
            player = collision.GetComponent<HealthPlayer>();
        }
    }

}
