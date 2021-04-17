using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herropea : MonoBehaviour
{
    public float fuerzaLanzamiento = 5;
    public float gravity = 1;
    public Transform pickUpPosition;
    public Transform scenario;
    private bool agarrando = false;
    private bool floating = true;
    private bool lanzamiento = false;
    DistanceJoint2D joint;  
    Rigidbody rb;
    private void Start()
    {
        joint = GetComponent<DistanceJoint2D>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Jump") && !agarrando)
        {
            agarrando = true;
            transform.position = new Vector3(pickUpPosition.position.x, pickUpPosition.position.y);
            transform.SetParent(pickUpPosition);
        }
        else if (Input.GetButton("Fire3"))
        {
            agarrando = false;
            transform.SetParent(scenario);
        }
        else if (Input.GetButton("Fire1") && agarrando)
        {
            agarrando = false;
            lanzamiento = true;
        }

        if (!agarrando && floating)
        {
            transform.Translate(Vector2.down * gravity * Time.deltaTime);
        }
    }

    public void AgarrarHerropea(Transform newParent)
    {
        //Desactivamos el componente joint que une la herropea al jugador
        joint.enabled = !joint.enabled;
        //Instancia el GO asociado a este script a un nuevo padre
        transform.SetParent(newParent, true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() != null)
        {
            Debug.Log("Suelo");
            floating = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<CompositeCollider2D>() != null)
        {
            Debug.Log("Flotando");
            floating = true;
        }
        
    }
}
