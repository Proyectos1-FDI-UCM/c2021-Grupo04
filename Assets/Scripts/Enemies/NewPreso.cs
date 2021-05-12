using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPreso : MonoBehaviour
{
    public float velocity = 3f;
    public float visionDistance = 1f;
    public Transform objetivo;

    Rigidbody2D rb;
    float distance;
    public bool follow = false;
    bool peaceFull = true;
    int movementDir = 1;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (distance < visionDistance)
        {
            follow = true;

            Debug.Log("vision distance: " + visionDistance);
            Debug.Log("Distance: " + distance);
            Debug.Log("follow: " + follow);
        }
    }
    void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, objetivo.transform.position);

        if (follow)
        {
            peaceFull = false;
            //Si el jugador está demasiado cerca, lo persigue
            if (objetivo.position.x < transform.position.x)
            {               
                transform.right = Vector2.left;
                rb.velocity = new Vector2(-velocity, rb.velocity.y);
            }
            else
            {
                transform.right = Vector2.right;
                rb.velocity = new Vector2(velocity, 0);
            }

        }
        else if(peaceFull)
        {
            rb.velocity = new Vector2(movementDir * velocity, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            follow = false;
        }
        else if (collision.GetComponent<Herropea>())
        {
            //if(!follow)
                //follow = true;
        }
        else
        {
            ChangeDir();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            follow = true;
        }
    }
    public void ChangeDir()
    {
        movementDir = movementDir * -1;
        if (movementDir == -1)
            transform.right = Vector2.left;
        else if (movementDir == 1)
            transform.right = Vector2.right;
    }
}
