using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //definimos variables
    public float vRun = 4;
    public float vJump = 5;
    public float vRunReduction = 0.8f;
    public float vJumpReduction = 0.8f;
    public GameObject herropea;

    Rigidbody2D rb;
    Animator anim;
    Herropea scriptHerropea;
    public bool contact;
    private float fRun;
    private float fJump;
    private float distance;
    private float maxDistance;
    private bool jump = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        scriptHerropea = herropea.GetComponent<Herropea>();
    }
    //detectamos cuando entra en contacto el collider de los pies de Maktfange con el escenario 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>())
        {
            contact = true;
            anim.SetBool("Floating", !contact);
        }
            
    }
    //detectamos salida
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>())
        {
            contact = false;
            anim.SetBool("Floating", !contact);
        }
            
    }

    void Update()
    {
       
        float run = Input.GetAxis("Horizontal");
        jump = Input.GetKey(KeyCode.UpArrow);

        distance = scriptHerropea.GetDistanceHerropea();
        maxDistance = scriptHerropea.GetMaxDistance();

        //Reducción de salto
        if (scriptHerropea.AgarrandoHerropea())
        {
            fRun = vRun;
            fJump = vJump * vJumpReduction;
        }
        //Reduccion de carrera
        else if (!scriptHerropea.AgarrandoHerropea() && distance >= (maxDistance - 0.1f))
        {
            fRun = vRun * vRunReduction;
            fJump = vJump;
        }
        else
        {
            fRun = vRun;
            fJump = vJump;
        }

        if (!Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(run * fRun, rb.velocity.y); //movimiento por el eje X
        }
        else rb.velocity = new Vector2(0, rb.velocity.y);

        if (run != 0)
        {
            anim.SetBool("Running", true);
            if (run < 0) transform.right = Vector2.left;
            else if (run > 0) transform.right = Vector2.right;
        }
        else anim.SetBool("Running", false);

        if(Input.GetButtonDown("Fire2"))
        {
            GameManager.GetInstance().ActivatePowerUp();
        }

    }

    public void SetPickUpAnimation(bool animation) 
    {             
        anim.SetBool("PickingUp", animation);       
    }

    private void FixedUpdate()
    {
        if (contact && jump && !Input.GetButton("Jump")) //si existe contacto, podemos saltar
        {
            anim.SetBool("Jump", true);
            Invoke("PlayerJumps", 0.1f);
            Invoke("SetFalseJump", 0.2f);
        }
    }

    private void PlayerJumps()
    {
        rb.velocity = new Vector2(rb.velocity.x, fJump);
    }

    private void SetFalseJump()
    {
        anim.SetBool("Jump", false);
    }

    public bool Salto()
    {
        return contact;
    }
}
