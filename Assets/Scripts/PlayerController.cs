using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //definimos variables
    public float vRun = 4;
    public float vJump = 5;
    public float vRunReduction;
    public float vJumpReduction;
    public GameObject herropea;

    Rigidbody2D rb;
    Animator walk;
    Herropea scriptHerropea;
    bool contact;
    private float fRun;
    private float fJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walk = GetComponentInChildren<Animator>();
        scriptHerropea = herropea.GetComponent<Herropea>();
    }
    //detectamos cuando entra en contacto el collider de los pies de Maktfange con el escenario 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>())
            contact = true;
    }
    //detectamos salida
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>())
            contact = false;
    }

    void Update()
    {
        //variables para correr y saltar
        float jump = Input.GetAxis("Vertical");
        float run = Input.GetAxis("Horizontal");

        if (scriptHerropea.AgarrandoHerropea())
        {
            fRun = vRun;
            fJump = vJump * vJumpReduction;
        }
        else
        {
            fRun = vRun * vRunReduction;
            fJump = vJump;
        }
        rb.velocity = new Vector2(run*fRun, rb.velocity.y); //movimiento por el eje X
        if (run != 0)
        {
            walk.SetBool("Running", true);
            if (run < 0) transform.right = Vector2.left;
            else if (run > 0) transform.right = Vector2.right;
        }
        else walk.SetBool("Running", false);


        if (contact) //si existe contacto, podemos saltar
        {
            rb.velocity = new Vector2(rb.velocity.x, jump * fJump);
        }

 
    }
}
