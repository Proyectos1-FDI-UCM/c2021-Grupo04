using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAT : MonoBehaviour
{
    //Alejandro
    public GameObject player;
    public GameObject parent;
    public GameObject swatRadio;
    public float gravity = 5f;

    [SerializeField] private float enemyVelocity = 1f;
    [SerializeField] private float delayToChangeDirection = 1f;
    [SerializeField] private float distance;
    [SerializeField] private float right = 1;
    [SerializeField] private float timer = 0.0f;
    [SerializeField] private float offset = 0.2f;

    [SerializeField] bool charging = false;
    [SerializeField] bool attack = false;
    [SerializeField] bool agressive = false;
    [SerializeField] bool flotando = true;

    Vector2 playerPos;
    
    Rigidbody2D rb, rbplayer;
    PlayerController playerController;
    EnemyDamageable enemyDamageable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbplayer = player.GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        enemyDamageable = GetComponent<EnemyDamageable>();
    }

    void Update()
    {
        //Destrucción del SWAT
        if (enemyDamageable.health < 0)
        {
            Destroy(this.gameObject);
        }

        timer -= Time.deltaTime;

        distance = Vector2.Distance(transform.position, player.transform.position);

        //Movimiento
        if ((agressive == false && charging == false && attack == false))//distance
        {
            parent.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            parent.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
            if (((enemyVelocity > 0 && transform.localScale.x == -1) || (enemyVelocity < 0 && transform.localScale.x == 1)) && (distance > 4 ||
                player.transform.position.y > transform.position.y + offset || player.transform.position.y < transform.position.y - offset))
            {
                ChangeDir();
            }

            if(rb.velocity.x != enemyVelocity)
            {
                rb.velocity = new Vector2(enemyVelocity, 0);
            }

            //Detecta si el jugador se encuentra a su espalda
            if (player.transform.position.y <= transform.position.y + offset && player.transform.position.y >= transform.position.y - offset)
            {
                if (transform.localScale.x == 1 && player.transform.position.x < transform.position.x && distance < 4)
                {
                    Invoke("ChangeDir", delayToChangeDirection);
                }
                else if (transform.localScale.x == -1 && player.transform.position.x > transform.position.x && distance < 4)
                {
                    Invoke("ChangeDir", delayToChangeDirection);
                }
            }
        }

        //Estado de carga 
        if (agressive == true && charging == true && attack == false)
        {
            rb.velocity = new Vector2(0, 0);
        }

        //Estado de ataque
        if (attack == true && charging == false && agressive == false)
        {
            //Cambio de sprites
            parent.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            parent.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);

            //Avanza hasta la posición del jugador guardada al momento de cargar
            //transform.position = Vector2.MoveTowards(transform.position, playerPos, Mathf.Abs(enemyVelocity) * 3 * Time.deltaTime);
            rb.velocity = new Vector2(3 * enemyVelocity, 0);

            //Si llega a esa posición guardada
            if ((transform.localScale.x == 1 && transform.position.x >= playerPos.x) || (transform.localScale.x == -1 && transform.position.x <= playerPos.x))
            {
                attack = false;
            }
        }

        //Percibe al jugador
        if (timer <= 0 && distance <= 4f && distance > 1f)
        {
            if (player.transform.position.y <= transform.position.y + offset && player.transform.position.y >= transform.position.y - offset)
            {
                if ((player.transform.position.x > transform.position.x && transform.localScale.x == 1)
                    || (player.transform.position.x < transform.position.x && transform.localScale.x == -1))
                {
                    Invoke("Charge", 0f);
                    timer = 3.0f;
                }
            }
        }
    }

    public bool IsCharging()
    {
        return charging;
    }

    //Carga
    private void Charge()
    {
        //Cambio de sprites
        parent.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        parent.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

        Instantiate(swatRadio);

        //Cambio de estados
        agressive = charging = true;
        attack = false;

        //Guarda la posición del jugador al moemento de cargar
        playerPos = new Vector2(player.transform.position.x, transform.position.y);

        Invoke("Attack", 1.5f);
    }

    //Ataque
    private void Attack()
    {
        //Cambio de estados
        attack = true;
        charging = agressive = false;
    }

    //Cambio de dirección
    public void ChangeDir()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        enemyVelocity *= -1;
        attack = agressive = charging = false;
        CancelInvoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colision");

        //Si colisiona con el jugador
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            parent.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            parent.transform.GetChild(0).GetChild(0).gameObject.SetActive(true);

            //Puntos específicos de colisión
            Vector2 hitSide = collision.contacts[0].normal;

            //Ángulo de colisión
            float angle = Vector2.Angle(hitSide, Vector3.up);

            //Colisión en el eje X
            if (Mathf.Approximately(angle, 90))
            {
                Vector3 side = Vector3.Cross(Vector3.forward, hitSide);

                //Colisión frontal
                if ((side.y < 0 && transform.localScale.x == 1) || (side.y > 0 && transform.localScale.x == -1))
                {
                    //rbplayer.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);

                    attack = false;
                    charging = agressive = true;
                }

                //Colisión trasera
                else if ((side.y < 0 && transform.localScale.x == -1) || (side.y > 0 && transform.localScale.x == 1))
                {
                    //right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
                    ChangeDir();
                    attack = false;
                    charging = agressive = true;
                }
            }
        }

        //Si colisiona con las paredes
        /*else if (collision.gameObject.GetComponent<CompositeCollider2D>() != null)
        {
            ChangeDir();
        }*/
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        /*if(collision.gameObject.GetComponent<CompositeCollider2D>() && flotando)
        {
            flotando = false;
        }*/
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        attack = charging = agressive = false;

        /*if (collision.gameObject.GetComponent<CompositeCollider2D>() && flotando)
        {
            flotando = true;
        }*/
    }

    /*public void Destroy()
    {
        Debug.Log("a");
        Destroy(this.gameObject);
    }*/
}
