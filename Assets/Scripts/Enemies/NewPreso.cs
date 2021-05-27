using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPreso : MonoBehaviour
{
    //Manu
    public float velocity = 3f;
    public Transform objetivo;
    Rigidbody2D rb;
    public bool follow = false;
    public bool peacefull = true;
    int movementDir = 1;
    private Herropea scriptHerropea;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //estados del preso

        //si está pacifico se mueve de manera normal
        if (peacefull)
        {
            rb.velocity = new Vector2(movementDir * velocity, 0);
        }
        // si ha visto al jugador lo perseguira indefinidamente
        if (follow)
        {
            if (objetivo.position.x < transform.position.x)
            {               
                transform.right = Vector2.left;
                rb.velocity = new Vector2(-velocity, rb.velocity.y);
            }

            else
            {
                transform.right = Vector2.right;
                rb.velocity = new Vector2(velocity, rb.velocity.y);
            }

        }

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // mejora del movimiento cuando el preso esta en contacto con el jugador
        if (collision.GetComponent<PlayerController>())
        {
            follow = false;

        }
        // deteccion de la herropea
        else if (collision.GetComponent<Herropea>())
        {
            scriptHerropea = collision.GetComponent<Herropea>();
            if (scriptHerropea.Lanzamiento())
            {
                Follow();
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            follow = true;
        }
    }
    // metodo para cambiar la dirección de movimiento
    public void ChangeDir()
    {
        movementDir = movementDir * -1;
        if (movementDir == -1)
            transform.right = Vector2.left;
        else if (movementDir == 1)
            transform.right = Vector2.right;
    }
    public void Follow()
    {
        if(peacefull)
        {
            peacefull = false;
            follow = true;
        }
    }
}
