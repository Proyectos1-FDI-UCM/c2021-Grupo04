using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    //variables

    public bool shoot = true; //Dispara si está a true
    public float coolingDownSecs = 0.4f;
    public float distanceToShoot = 8f;

    public GameObject Player;
    public GameObject Policeman;
    public GameObject Bullet;

    private float lastShoot = 0;

    private void Update()
    {
        //distancia (en valor absoluto) entre jugador y policía
        float distance = Mathf.Abs(Player.transform.position.x - Policeman.transform.position.x);
        //si dicha distancia es menor de 8 y el tiempo de ejecución es mayor que el tiempo que ha pasado desde el último disparo + el tiempo de cool down, 
        //invocamos el método y actualizamos el ultimo disparo

        if(distance < distanceToShoot && Time.time > lastShoot + coolingDownSecs)
        {
            Debug.Log("Policia ");
            if (shoot)
            {
                Shoot();
                lastShoot = Time.time;
            }
        }
    }
    private void Shoot()
    {
        //guardamos rotación y dirección del  policía e instanciamos la bala
        Vector3 direction = transform.position;
        Quaternion rotation = transform.rotation;

        Instantiate(Bullet, direction, rotation);
    }

}

    


