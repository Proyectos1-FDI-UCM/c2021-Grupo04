using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform maktFange;// transform público editable desde unity (metemos a MaktFange en el hueco)
    private Vector3 difference;
    void Start()
    {
        difference = transform.position - maktFange.position;//guardamos distancia con respecto al jugador
    }

    
    void LateUpdate()
    {
        transform.position = maktFange.position + difference;//actualizamos la posición para siempre guardar la misma distancia
    }
}
