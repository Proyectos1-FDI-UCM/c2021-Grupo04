using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Shooter : MonoBehaviour
{

    //variables

    public bool shoot = true; //Dispara si está a true
    public float coolingDownSecs = 0.4f;
    public float distanceToShoot = 8f;

    public Transform Player;
    public Transform Policeman;
    public Sprite copShoot, copShoot1;
    public UnityEngine.GameObject Bullet;
    public UnityEngine.GameObject shootSound;

    SpriteRenderer spriteRenderer;
    Sprite orSprite;
    private float lastShoot = 0;

    private void Start()
    {
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
        //Guardamos el spite idle
        orSprite = spriteRenderer.sprite;
    }

    private void Update()
    {
        //distancia (en valor absoluto) entre jugador y policía
        float distance = Mathf.Abs(Player.transform.position.x - Policeman.transform.position.x);
        //si dicha distancia es menor de 8 y el tiempo de ejecución es mayor que el tiempo que ha pasado desde el último disparo + el tiempo de cool down, 
        //invocamos el método y actualizamos el ultimo disparo

        if(distance < distanceToShoot)
        {
            //Nos aseguramos de que no hemos cambiado el sprite ya al que queremos
            if (spriteRenderer.sprite != copShoot)
                Invoke("CancelSpriteShoot1", 0.25f);

            if (Time.time > lastShoot + coolingDownSecs && shoot)
            {
                Shoot();
                lastShoot = Time.time;
                
            }
            
        }
        else
        {
            //Si el jugador se aleja, el jugador guarda la pistola
            if (spriteRenderer.sprite != orSprite)
                spriteRenderer.sprite = orSprite;
        }
    }
    private void Shoot()
    {
        //guardamos rotación y dirección del  policía e instanciamos la bala
        Vector3 direction = transform.position;
        Quaternion rotation = transform.rotation;
        Instantiate(shootSound);
        Instantiate(Bullet, direction, rotation);
        //cambiamos al sprite de disparo y lo cancelamos al instante
        ShootingSprite1();
    }

    private void ShootingSprite1()
    {
        spriteRenderer.sprite = copShoot1;
    }

    private void CancelSpriteShoot1()
    {
        spriteRenderer.sprite = copShoot;
    }
}

    


