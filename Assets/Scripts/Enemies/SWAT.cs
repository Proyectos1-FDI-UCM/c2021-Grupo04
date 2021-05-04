using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAT : MonoBehaviour
{
    [SerializeField] private Transform[] movPoints;
    private int i = 0;
    public GameObject player;
    [SerializeField] private float enemyVelocity = 1.5f;
    [SerializeField] private float delayToChangeDirection = 1f;

    private Vector3 iniScale, tempScale, movement;
    private float right = 1;

    Rigidbody2D rb, rbplayer;
    bool charging = false, chargeLeft = false, chargeRight = false;
    bool moveRight;
    bool agressive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbplayer = player.GetComponent<Rigidbody2D>();
        iniScale = transform.localScale;
    }

    void Update()
    {
        /*if (moveRight)
        {
            transform.Translate(Time.deltaTime * enemyVelocity, 0, 0);
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * enemyVelocity, 0, 0);
            transform.localScale = new Vector2(-1f, 1f);
        }*/

        if (agressive == false && !charging)
        {
            transform.position = Vector2.MoveTowards(transform.position, movPoints[i].transform.position, enemyVelocity * Time.deltaTime);
        }
        else if(agressive == true && charging)
        {
            transform.position = transform.position;             
            if (transform.right == Vector3.left && player.transform.position.x > transform.position.x)
            {
                Invoke("ChangeDirection", delayToChangeDirection);
            }
            else if (transform.right == Vector3.right && player.transform.position.x < transform.position.x)
            {
                Invoke("ChangeDirection", delayToChangeDirection);
            }
        }
        if (Vector2.Distance(transform.position, movPoints[i].transform.position) < 0.5f)
        {
            if (movPoints[i] != movPoints[movPoints.Length - 1]) i++;
            else i = 0;
            right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
            Turn(right);
        }
        

    }

    private void Charge(ref bool agressive)
    {
        agressive = !agressive;
        if(agressive == true)
        {
            charging = !charging;
            Invoke("Attack", 3);
        }
        else
        {
            
        }
    }

    private void Attack()
    {
        rb.AddForce(new Vector2(enemyVelocity * Time.deltaTime * 3, 0), ForceMode2D.Force);

        /*if (Vector2.Distance(transform.position, movPoints[i].transform.position) < 0.5f)
        {
            if (movPoints[i] != movPoints[movPoints.Length - 1]) i++;
            else i = 0;
            right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
            Turn(right);
        }*/

    }

    private void Turn(float right)
    {
        if (right == -1)
        {
            tempScale = transform.localScale;
            tempScale.x = tempScale.x * -1;
        }
        else tempScale = iniScale;
        transform.localScale = tempScale;
    }

    /*private void OnTriggerEnter2D(Collider2D collider)
    {
        if(!collider.gameObject.GetComponent<PlayerController>() && !collider.gameObject.GetComponent<Herropea>())
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
        }

        if (!collider.gameObject.GetComponent<Herropea>())
        {
            agressive = true;
            if(rb.transform.position.x < player.transform.position.x)
            {
                rb.transform.localScale = new Vector2(-1f, 1f);
            }
            if (rb.transform.position.x > player.transform.position.x)
            {
                rb.transform.localScale = new Vector2(1f, 1f);
            }
        }
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!charging)
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                Charge(ref agressive);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (Vector2.Distance(this.transform.position, player.transform.position) <= 3f)
        {
            
        }
        else
        {
            agressive = false;
            charging = !charging;
        }
    }

    /// <summary>
    /// El GO asociado cambia su dirección hacia la del GO asociado
    /// </summary>
    private void ChangeDirection()
    {
        //Dependiendo de la posición del jugador respecto al SWAT, este último girará su transform right a derecha o izquierda
        if (player.transform.position.x < transform.position.x)
        {
            transform.right = Vector3.right;
        }
        else
        {
            transform.right = Vector3.left;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        rbplayer.AddForce(new Vector2(5, 0), ForceMode2D.Impulse);
    }*/
}
