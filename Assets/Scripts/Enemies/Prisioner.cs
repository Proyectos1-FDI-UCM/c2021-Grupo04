using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisioner : MonoBehaviour
{
    public GameObject player;
    public float velocityScale = 3;
    public int damage = 2;
    public float initCooldown = 100;
    int movementDir = 1;
    bool agresivo = false;
    Rigidbody2D rb;
    float distance;
    public float attackDistance;
    public bool undetected = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > attackDistance)
        {
            ChangeDirection();
        }
        else
        {
            rb.velocity = new Vector2(-velocityScale, rb.velocity.y);
        }   
                
                
                    
                


            

    }
   
    
   
    //Determina si el enemigo entra en contacto con el jugador y le quita vida
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            agresivo = true;
            
            Debug.Log("He visto al jugador");
        }
    }
   

    public void ChangeDirection()
    {
        movementDir = movementDir * -1;
        
        if (movementDir == -1)
        {
            transform.right = Vector2.left;
        }
            
        else if (movementDir == 1)
        {
            transform.right = Vector2.right;
        }
        undetected = true;
    }
   
   
}
