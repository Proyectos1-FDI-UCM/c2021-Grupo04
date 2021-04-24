using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //definimos variables
    public float vRun = 4;
    public float vJump = 5;
    Rigidbody2D rb;
    Animator walk;
    bool contact;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walk = GetComponentInChildren<Animator>();
    }
    //detectamos cuando entra en contacto el collider de los pies de Maktfange con el escenario 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>())
            contact = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>())
            contact = false;
    }


    void Update()
    {
        float jump = Input.GetAxis("Vertical");
        float run = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(run*vRun, rb.velocity.y); //movimiento por el eje X
        if (run != 0)
        {
            walk.SetBool("Running", true);
            if (run < 0) transform.right = Vector2.left;
            else if (run > 0) transform.right = Vector2.right;
        }
        else walk.SetBool("Running", false);


        if (contact) //si existe contacto, podemos saltar
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * vJump);
        }

    }
}
