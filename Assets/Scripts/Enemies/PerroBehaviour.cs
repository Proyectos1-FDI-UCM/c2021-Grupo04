using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PerroBehaviour : MonoBehaviour
{
    //Declaración de variables (las variables públicas son temporales, son para modificar el código más fácilmente
    public float distanciaAtaque;
    public float velocidad;
    public int damage;

    private UnityEngine.GameObject objetivo;
    private float distancia;
    private float initCooldown = 2;

    private bool atacar;
    private float lastbite;
    private bool detectado = false;

    //Mira si el objetivo ha sido detectado y si ha cambiado de lado
    void Update()
    {

        if (detectado)
        {
            if (objetivo.transform.position.x < transform.position.x)
            {
                transform.right = Vector2.left;
            }
            else
            {
                transform.right = Vector2.right;
            }

            Perseguir2();
        }
    }

    //Si lo que detecta el campo de vision tiene PlayerController, ese objeto pasa a ser el objetivo
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Jugador detectado");
            detectado = true;
            objetivo = collider.gameObject;


        }
    }


    //Persigue si el jugador está a mayor distancia que la que puede atacar, ataca si le alcanza
    void Perseguir2()
    {
        distancia = Vector2.Distance(transform.position, objetivo.transform.position);

        if (distancia > distanciaAtaque)
        {
            Mover2();
            atacar = false;
        }
        else if (distanciaAtaque >= distancia)
        {
            atacar = true;
            Atacar();
            Debug.Log("He visto al jugador");
        }
    }

    //Mueve al enemigo hacia el objetivo a una velocidad determinada
    void Mover2()
    {
        Vector2 posicionObjetivo = new Vector2(objetivo.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, posicionObjetivo, velocidad * Time.deltaTime);

    }
    public void Atacar()
    {
        if (atacar && Time.time > initCooldown + lastbite)
        {
            Debug.Log("Ataque");
            
            
            lastbite = Time.time;           
            
        }
    }
}
