using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform maktFange;// transform público editable desde unity (metemos a MaktFange en el hueco)
    public float cameraOffSetX=0;
    public float cameraOffSetY = 0;
    private Vector3 difference;
    void Start()
    {
        Vector3 posFange = new Vector3(maktFange.position.x+cameraOffSetX, maktFange.position.y+cameraOffSetX, transform.position.z);
        transform.position = posFange;
        difference = transform.position - maktFange.position;//guardamos distancia con respecto al jugador

    }

    
    void LateUpdate()
    {
        transform.position = maktFange.position + difference;//actualizamos la posición para siempre guardar la misma distancia
    }
}
