using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preso : MonoBehaviour
{
    public GameObject player;
    public float velocityScale = 3;
    public int damage = 2;
    public float initCooldown = 100;
    int movementDir = 1;
    bool agresivo = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!agresivo)
        {
            rb.velocity = new Vector2(movementDir * velocityScale, 0);
        }
        else if (agresivo)
        {
            EncontrarJugador();
        }
    }
    //triggers para el control del enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // trigger que delimitan el movimiento
        if (!collision.gameObject.GetComponent<PlayerController>())
        {
            CambioDir();
        }
        // trigger que funciona como campo de visión
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            agresivo = true;
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            agresivo = false;
        }
    }
    //Determina si el enemigo entra en contacto con el jugador y le quita vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Herropea>() /*|| collision.gameObject.GetComponent<PlayerController>()*/)
        {
            agresivo = true;
        }
    }
    //Metodo donde debe ir el comportamiento del enemigo una vez haya detectado al jugador
    public void EncontrarJugador()
    {
        if (player.transform.position.x > rb.transform.position.x)
        {
            movementDir = 1;
            rb.velocity = new Vector2(movementDir * velocityScale, 0);
            transform.right = Vector2.right;
        }
        else if (player.transform.position.x < rb.transform.position.x)
        {
            movementDir = -1;
            transform.right = Vector2.left;
        }
        rb.velocity = new Vector2(movementDir * velocityScale, 0);
    }

    public void CambioDir()
    {
        movementDir = movementDir * -1;
        if (movementDir == -1)
            transform.right = Vector2.left;
        else if (movementDir == 1)
            transform.right = Vector2.right;
    }
}
