using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerropeaBehaviour : MonoBehaviour
{
    public float maxDistance;
    public Rigidbody2D rbMakt;
    public Transform chainZone;   
    private float distance;

    // Update is called once per frame
    void Update()
    {
        float step = rbMakt.velocity.sqrMagnitude * Time.deltaTime;
        //Guardamos la distancia entre Makt y la herropea
        distance = Vector2.Distance(chainZone.transform.position, transform.position);
        if (distance >= maxDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, chainZone.transform.position, step);
        }     
    }
}
