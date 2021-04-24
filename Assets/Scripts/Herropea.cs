using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herropea : MonoBehaviour
{
    public float velLanzamiento = 5;
    public float gravity = 1;
    public float maxDistance;
    public int damage;
    public Transform pickUpPosition;
    public Transform chainZone;
    public Transform scenario;
    public Rigidbody2D rbMakt;

    private float distance; //Distancia bola jugador
    private bool agarrando = false; //Si Makt Fange esta agarrando la bola
    private bool floating = true; //True si es afectada por la gravedad
    private bool lanzamiento = false; //Si la bola está viajando por un lanzamento de Makt Fange
    

    void Update()
    {
        float step = rbMakt.velocity.sqrMagnitude * Time.deltaTime;
        //Guardamos la distancia entre Makt y la herropea
        distance = Vector2.Distance(chainZone.transform.position, transform.position);
        if (distance >= maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, chainZone.transform.position, step);
        }

        // El jugador agarra la herropea si no lo está haciendo ya
        if (Input.GetButton("Jump") && !agarrando)
        {
            agarrando = true;
            transform.position = new Vector3(pickUpPosition.position.x, pickUpPosition.position.y);
            transform.SetParent(pickUpPosition);
            transform.rotation = transform.parent.rotation;
        }
        // El jugador deja de agarrar la herropea con shift
        else if (Input.GetButton("Fire3"))
        {
            agarrando = false;
            transform.SetParent(scenario);
        }
        //El jugador lanza si está agarrando y pulsa ctrl
        else if (Input.GetButton("Fire1") && agarrando)
        {
            Debug.Log("Lanzamiento");                   
            lanzamiento = true;
            transform.SetParent(scenario);
        }

        //Siempre que no esté agarrando Fange la bola y que el bool floating sea true, le afecta la gravedad
        if (!agarrando && floating)
        {
            transform.Translate(Vector2.down * gravity * Time.deltaTime);
        }       

        //La herropea avanza si Makt Fange usa su ataque Lanzamiento Forzoso
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
                 
    }

    /// <summary>
    /// Devuelve true si MaktFange ha usado Lanzamiento Forzoso
    /// </summary>
    /// <returns></returns>
    public bool LanzamientoForzoso()
    {
        if (lanzamiento)
            return true;
        else return false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //La gravedad vuelve a afectar a la herropea al colisionar con el tilemap o con el policía
        if(collision.GetComponent<CompositeCollider2D>() != null)
        {
            Debug.Log("Flotando");
            floating = true;
        }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Guardamos la referencia del enemigo en una variable para acceder luego a un método suyo
        EnemyDamageable enemigo = collision.GetComponent<EnemyDamageable>();

        if (collision.GetComponent<CompositeCollider2D>() != null)
        {
            floating = false; //Deja de afectarle la gravedad
            Debug.Log("Suelo");
            //Si además la bola ha sido lanzada por MaktFange, se queda clavada en la pared
            if (lanzamiento)
            {
                lanzamiento = false;
                agarrando = false;
                floating = false;
            }
        }
        else if (enemigo)
        {
            if (lanzamiento)
            {
                enemigo.GetDamage(damage);
                lanzamiento = false;
                agarrando = false;
            }
        }
    }
}
