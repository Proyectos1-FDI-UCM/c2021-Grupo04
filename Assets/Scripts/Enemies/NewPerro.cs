using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPerro : MonoBehaviour
{
    //Miguel y Edu
    public float velocity = 3f;
    public float maxDistanceToChase = 8f;
    public Transform objetivo;
    public GameObject barkSound;
    public Animator animator;

    Rigidbody2D rb;
    float distance;
    bool movement = true;
    // Update is called once per frame
    void Update()
    {
        //Comprobamos la distancia entre el jugador y el perro 
        distance = Vector2.Distance(transform.position, objetivo.transform.position);
        rb = GetComponent<Rigidbody2D>();
      
    }

    void FixedUpdate()
    {
        if (movement)
        {
            //Si el jugador está demasiado cerca, lo persigue
            if (objetivo.position.x < transform.position.x)
            {
                
                transform.right = Vector2.left;
                
                if (distance <= maxDistanceToChase)
                {
                    animator.SetBool("Perseguido", true);
                    rb.velocity = new Vector2(-velocity, rb.velocity.y);                   
                }
                else
                {
                    animator.SetBool("Perseguido", false);
                    rb.velocity = new Vector2(0, 0);
                }
                    
            }
            else
            {
                transform.right = Vector2.right;
                if (distance <= maxDistanceToChase)
                {
                    animator.SetBool("Perseguido", true);
                    rb.velocity = new Vector2(velocity, 0);
                }
                else
                {
                    animator.SetBool("Perseguido", false);
                    rb.velocity = new Vector2(0, 0);
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            movement = false;
            Instantiate(barkSound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            movement = true;
            
        }
    }

    
}
