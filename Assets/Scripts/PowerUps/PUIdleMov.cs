using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUIdleMov : MonoBehaviour
{
    //Miguel
    public float timeToInvert =1f;
    public float yMov = 0.5f;
    private float cooldown = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * yMov * Time.deltaTime);
        if (Time.time >= cooldown + timeToInvert)
        {
            cooldown = Time.time;
            ChangeDir();
        }
    }

    //cambia el sentido en el que el power up se mueve por el eje y
    public void ChangeDir()
    {
        yMov *= -1;
    }
}
