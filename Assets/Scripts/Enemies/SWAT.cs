using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAT : MonoBehaviour
{
    float enemyVelocity = 1.5f;
    Rigidbody2D rb;
    public bool moveRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Time.deltaTime * enemyVelocity, 0, 0);
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime * enemyVelocity, 0, 0);
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
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
}
