using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    //Miguel
    public Transform chainZone;
    LineRenderer lineRenderer;
    Herropea herropea;

    private void Start()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        herropea = GetComponent<Herropea>();
    }
  
    void Update()
    {
        if (!herropea.AgarrandoHerropea() || herropea.Lanzamiento())
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, chainZone.position);
        }        
    }
}
