using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedJump : MonoBehaviour
{
    public float mediumJumpForce = 1f;
    public float fastDescending = 1.5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si el jugador ha saltado, y al ejecutarse esta instrucción no sigue pulsando el botón
        if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow))
        {
            //Al jugador se le suma velocidad hacia abajo para que caiga más rápido
            rb.velocity += Vector2.up * Physics2D.gravity.y * mediumJumpForce * Time.deltaTime;
        }
        else if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * mediumJumpForce * Time.deltaTime;
        }
    }
}
