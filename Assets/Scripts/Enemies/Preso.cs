using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preso : MonoBehaviour
{
    public GameObject player;
    public float velocityScale = 3;
    public int damage = 2;
    public float initCooldown = 100;
    float cooldown;
    int movementDir = 1;
    bool cooling = false;
    bool agresivo = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cooldown = initCooldown;
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
        if (cooling)
            Debug.Log("cooldown");

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
            velocityScale = velocityScale * 1.5f;
            agresivo = true;
            Debug.Log("He visto al jugador");
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            agresivo = false;
            velocityScale = velocityScale / 1.5f;
        }
    }
    //Determina si el enemigo entra en contacto con el jugador y le quita vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            agresivo = true;
            Atacar();
            Debug.Log("He visto al jugador");
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
    public void Atacar()
    {
        if (agresivo && !cooling)
        {
            //GameManager.GetInstance().MakeDamage(damage);
            cooling = true;
            Cooldown();
        }
    }
    public void Cooldown()
    {
        while (cooling)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0 && agresivo && cooling)
            {
                cooling = false;
                cooldown = initCooldown;
            }
        }
    }
    //original(unity)
}
