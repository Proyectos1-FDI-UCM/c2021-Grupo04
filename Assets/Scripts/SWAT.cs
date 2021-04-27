using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAT : MonoBehaviour
{
    [SerializeField] private Transform[] movPoints;
    private int i = 0;
    public GameObject player;
    [SerializeField] private float enemyVelocity = 1.5f;

    private Vector3 iniScale, tempScale, movement;
    private float right = 1;

    Rigidbody2D rb;
    bool charging = false, chargeLeft = false, chargeRight = false;
    bool moveRight;
    bool agressive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

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

        if(agressive == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, movPoints[i].transform.position, enemyVelocity * Time.deltaTime);
        }
        else
        {
            transform.position = transform.position;
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
            Invoke("Wait", 2);
        }
        else
        {
            Update();
        }
    }

    private void Wait()
    {
        Invoke("Charge", 0);
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
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Charge(ref agressive);
        }
        
    }
}
