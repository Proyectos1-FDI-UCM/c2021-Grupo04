using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocityScale;
    public int  damage = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * velocityScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject, 0);
        //Si colisiona con el jugador
        if (other.GetComponent<PlayerController>())
        {
            GameManager.GetInstance().LoseHearts(damage);
        }
    }
}
