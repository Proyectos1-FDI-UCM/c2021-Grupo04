using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herropea : MonoBehaviour
{
    public float velLanzamiento = 5;
    public float gravity = 1;
    public float maxDistance;
    public Transform pickUpPosition;
    public Transform chainZone;
    public Transform scenario;
    public Rigidbody2D rbMakt;
    private float distance;
    private bool agarrando = false;
    private bool floating = true;
    private bool lanzamiento = false;
    

    void Update()
    {
        float step = rbMakt.velocity.sqrMagnitude * Time.deltaTime;
        //Guardamos la distancia entre Makt y la herropea
        distance = Vector2.Distance(chainZone.transform.position, transform.position);
        if (distance >= maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, chainZone.transform.position, step);
        }

        if (Input.GetButton("Jump") && !agarrando)
        {
            agarrando = true;
            transform.position = new Vector3(pickUpPosition.position.x, pickUpPosition.position.y);
            transform.SetParent(pickUpPosition);
            transform.rotation = transform.parent.rotation;
        }
        else if (Input.GetButton("Fire3"))
        {
            agarrando = false;
            transform.SetParent(scenario);
        }
        else if (Input.GetButton("Fire1") && agarrando)
        {
            Debug.Log("Lanzamiento");                   
            lanzamiento = true;
            transform.SetParent(scenario);
        }

        if (!agarrando && floating)
        {
            transform.Translate(Vector2.down * gravity * Time.deltaTime);
        }       

        if (lanzamiento)
        {           
            transform.Translate(Vector2.right * velLanzamiento * Time.deltaTime);
            if (distance >= maxDistance) 
            {
                lanzamiento = false;
                transform.SetParent(scenario);
                agarrando = false;             
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() != null)
        {
            Debug.Log("Suelo");
            floating = false;
            if (lanzamiento)
            {
                lanzamiento = false;
                agarrando = false;
                floating = false;
            }
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
