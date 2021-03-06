using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Adrián,Miguel

    //definimos variables
    public float vRun = 4;
    public float vJump = 5;
    public float vRunReduction = 0.8f;
    public float vJumpReduction = 0.8f;
    public GameObject herropea;
    public GameObject saltoFange;
    Rigidbody2D rb;
    Animator anim;
    Herropea scriptHerropea;
    public bool contact;
    private float fRun;
    private float fJump;
    private float distance;
    private float maxDistance;
    private bool jump = false;
    //Variables para delimitar el movimiento en el eje x
    private bool movRight = true;
    private bool movLeft = true; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        scriptHerropea = herropea.GetComponent<Herropea>();
    }

    //detectamos cuando entra en contacto el collider de los pies de Maktfange con el escenario 
    //Para solucionar errores en la build, ahora hacemos una comprobación continua
    private void OnTriggerStay2D(Collider2D collision)
    {
        if((collision.GetComponent<CompositeCollider2D>() || collision.GetComponent<DestroyFakeHerropea>()) && contact == false)
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

        if (run != 0)
        {
            anim.SetBool("Running", true);
            if (run < 0)
            {
                transform.right = Vector2.left;
            }
            else if (run > 0)
            {
                transform.right = Vector2.right;
            }
        }
        else anim.SetBool("Running", false);

        //Movimiento del jugador
        if (!Input.GetButton("Jump"))
        {
            if (run > 0 && movRight)
            {
                rb.velocity = new Vector2(fRun, rb.velocity.y); //movimiento por el eje X en positivo
            }
            else if (run < 0 && movLeft)
            {
                rb.velocity = new Vector2(-fRun, rb.velocity.y); //movimiento por el eje X en negativo
            }
            else rb.velocity = new Vector2(0, rb.velocity.y);
        }
        else rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetButtonDown("Fire2"))
        {
            GameManager.GetInstance().ActivatePowerUp();
        }
        if (contact)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Instantiate(saltoFange);
            }
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

    /// <summary>
    /// Habilita el movimiento hacia la derecha del jugador en función del parámetro move
    /// </summary>
    /// <param name="move"></param>
    public void SetMovRight(bool move)
    {
        movRight = move;
    }

    /// <summary>
    /// Habilita el movimiento hacia la izquierda del jugador en función del parámetro move
    /// </summary>
    /// <param name="move"></param>
    public void SetMovLeft(bool move)
    {
        movLeft = move;
    }
}
