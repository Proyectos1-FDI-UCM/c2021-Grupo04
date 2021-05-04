using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWAT : MonoBehaviour
{
    [SerializeField] private Transform[] movPoints;
    private int i = 0;
    public GameObject player;
    public GameObject parent;
    [SerializeField] private float enemyVelocity = 1.5f;
    [SerializeField] private float delayToChangeDirection = 1f;
    [SerializeField] private float distance;

    private Vector3 iniScale, tempScale, movement;
    Vector2 playerPos;
    private float right = 1;

    Rigidbody2D rb, rbplayer;
    bool charging = false;
    bool attack = false;
    bool agressive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rbplayer = player.GetComponent<Rigidbody2D>();
        iniScale = transform.localScale;
    }

    void LateUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (agressive == false && charging == false && attack == false)
        {
            parent.transform.GetChild(0).gameObject.SetActive(false);
            parent.transform.GetChild(3).gameObject.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, movPoints[i].transform.position, enemyVelocity * Time.deltaTime);
        }
        if (agressive == true && charging == true && attack == false)
        {
            transform.position = transform.position;
            if (transform.right == Vector3.left && player.transform.position.x > transform.position.x)
            {
                Invoke("ChangeDirection", delayToChangeDirection);
            }
            else if (transform.right == Vector3.right && player.transform.position.x < transform.position.x)
            {
                Invoke("ChangeDirection", delayToChangeDirection);
            }
        }
        if (attack == true && charging == false && agressive == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos, enemyVelocity * 3 * Time.deltaTime);
        }
        //if(playerPos.x <= transform.position.x)

        if (Vector2.Distance(transform.position, movPoints[i].transform.position) < 0.5f)
        {
            if (movPoints[i] != movPoints[movPoints.Length - 1]) i++;
            else i = 0;
            right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
            Turn(right);
            agressive = false;
            attack = false;
            charging = false;
        }

    }

    private void Charge(ref bool agressive)
    {
        parent.transform.GetChild(3).gameObject.SetActive(false);
        parent.transform.GetChild(0).gameObject.SetActive(true);
        agressive = true;
        charging = true;
        attack = false;
        Invoke("Attack", 1.5f);

        /*if(agressive == true)
        {
            charging = true;
            Invoke("Attack", 3);
        }
        else
        {
            
        }*/
    }

    private void Attack()
    {
        attack = true;
        charging = false;
        agressive = false;
        playerPos = new Vector2(player.transform.position.x, transform.position.y);

        /*if (Vector2.Distance(transform.position, movPoints[i].transform.position) < 0.5f)
        {
            if (movPoints[i] != movPoints[movPoints.Length - 1]) i++;
            else i = 0;
            right = Mathf.Sign(movPoints[i].transform.position.x - transform.position.x);
            Turn(right);
        }*/
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (charging == false)
        {
            if (collision.gameObject.GetComponent<PlayerController>())
            {
                Charge(ref agressive);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        attack = false;
        charging = false;
        agressive = false;
        CancelInvoke();
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
        rbplayer.AddForce(new Vector2(10, 4), ForceMode2D.Impulse);
        attack = false;
        charging = false;
        agressive = true;
    }
}
