using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Player;
    public GameObject Policeman;
    public GameObject Bullet;

    private float lastShoot;
    private float coolingDownSecs=0.4f;

    private void Update()
    {
        float distance = Mathf.Abs(Player.transform.position.x - Policeman.transform.position.x);

        if(distance <8.0f && Time.time > lastShoot + coolingDownSecs)
        {
            Shoot();
            lastShoot = Time.time;
        }
    }
    private void Shoot()
    {
        Vector3 direction = transform.position;
        Quaternion rotation = transform.rotation;

        Instantiate(Bullet, direction, rotation);
    }

}

    


