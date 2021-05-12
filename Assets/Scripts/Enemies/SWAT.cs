using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAT : MonoBehaviour
{
    [SerializeField] private Transform[] movPoints;
    private int i = 0;
    public GameObject player;
    public GameObject parent;
    [SerializeField] private float enemyVelocity = 1f;
    [SerializeField] private float delayToChangeDirection = 1f;
    [SerializeField] private float distance;
    [SerializeField] bool charging = false;
    [SerializeField] bool attack = false;
    [SerializeField] bool agressive = false;
    public GameObject swatRadio;
    private Vector3 iniScale, tempScale;
    Vector2 playerPos;
    private float right = 1;
    float timer = 0.0f;
    float offset = 0.2f;

    Rigidbody2D rb, rbplayer;
    PlayerController playerController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbplayer = player.GetComponent<Rigidbody2D>();
        iniScale = transform.localScale;
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        distance = Vector2.Distance(transform.position, player.transform.position);

        if ((agressive == false && charging == false && attack == false) || (distance > 4))
        {
            parent.transform.GetChild(0).gameObject.SetActive(false);
            parent.transform.GetChild(2).gameObject.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, movPoints[i].transform.position, enemyVelocity * Time.deltaTime);
        }

        if (agressive == true && charging == true && attack == false)
        {
            transform.position = transform.position;
            
            /*if (transform.right == Vector3.left && player.transform.position.x > transform.position.x)
            {
                Invoke("ChangeDirection", delayToChangeDirection);
            }
            else if (transform.right == Vector3.right && player.transform.position.x < transform.position.x)
            {
                Invoke("ChangeDirection", delayToChangeDirection);
            }*/
        }

        if (attack == true && charging == false && agressive == false && distance <= 4)
        {
            if((playerPos.x > transform.position.x && transform.localScale.x == 1) || (playerPos.x < transform.position.x && transform.localScale.x == -1))
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPos, enemyVelocity * 3 * Time.deltaTime);
                if (transform.position.x == playerPos.x)
                {
                    attack = false;
                    agressive = charging = true;
                }
            }
            else
            {
                attack = charging = agressive = false;
            }
            
        }

        if (timer <= 0 && distance <= 4 && distance > 1f)
        {
            if(player.transform.position.y <= transform.position.y + offset && player.transform.position.y >= transform.position.y - offset)
            {
                if((player.transform.position.x > transform.position.x && transform.localScale.x == 1) 
                    || (player.transform.position.x < transform.position.x && transform.localScale.x == -1))
                {
                    Invoke("Charge", 0f);
                    timer = 3.0f;
                }
            }
        }

        if (Vector2.Distance(transform.position, movPoints[i].transform.position) < 0.1f)
        {
            if (movPoints[i] != movPoints[movPoints.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }
            right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
            Turn(right);
        }
    }

    private void Charge()
    {
        //Cambio de sprites
        parent.transform.GetChild(2).gameObject.SetActive(false);
        parent.transform.GetChild(0).gameObject.SetActive(true);
        Instantiate(swatRadio);
        agressive = charging = true;
        attack = false;
        
        Invoke("Attack", 1.5f);
        
    }

    private void Attack()
    {
        attack = true;
        charging = agressive = false;
        playerPos = new Vector2(player.transform.position.x, transform.position.y);

        /*if (Vector2.Distance(transform.position, movPoints[i].transform.position) < 0.5f)
        {
            if (movPoints[i] != movPoints[movPoints.Length - 1]) i++;
            else i = 0;
            right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
            Turn(right);
        }*/
    }
    
    //Cambiar de dirección
    private void Turn(float right)
    {
        if (right == -1)
        {
            tempScale = transform.localScale;
            tempScale.x = tempScale.x * -1;
        }
        else tempScale = iniScale;
        transform.localScale = tempScale;
    }

    /// El GO asociado cambia su dirección hacia la del GO asociado
    private void ChangeDirection()
    {
        //Dependiendo de la posición del jugador respecto al SWAT, este último girará su transform right a derecha o izquierda
        if (player.transform.position.x < transform.position.x)
        {
            transform.right = Vector3.right;
        }
        else if (player.transform.position.x >= transform.position.x)
        {
            transform.right = Vector3.left;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Puntos específicos de colisión
        Vector2 hitSide = collision.contacts[0].normal;

        //Ángulo de colisión
        float angle = Vector2.Angle(hitSide, Vector3.up);

        //Colisión en el eje X
        if(Mathf.Approximately(angle, 90))
        {
            Vector3 side = Vector3.Cross(Vector3.forward, hitSide);

            //Colisión frontal
            if((side.y < 0 && transform.localScale.x == 1) || (side.y > 0 && transform.localScale.x == -1))
            {
                rbplayer.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);

                attack = false;
                charging = agressive = true;
            }
        }  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        attack = charging = agressive = false;
    }
}
