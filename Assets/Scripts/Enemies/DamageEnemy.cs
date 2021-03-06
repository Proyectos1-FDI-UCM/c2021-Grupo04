using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    //Miguel
    public int damage = 1;

    SWAT swat;
    Shield shield;
    NewPreso preso;
    public Animator animator;

    private void Start()
    {
        swat = GetComponentInChildren<SWAT>();
        preso = GetComponentInParent<NewPreso>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HealthPlayer player = collision.GetComponent<HealthPlayer>();
        if (preso != null)
        {
            if (player != null)
            {
                animator.SetBool("Atizando", true);
                player.LoseHearts(damage);
            }

        }
        else
        {
            //Si colisiona con el jugador
            if (player != null)
            {
                player.LoseHearts(damage);
            }
        }        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        shield = GetComponentInChildren<Shield>();
        Debug.Log("collision stay");
        HealthPlayer player = collision.collider.GetComponent<HealthPlayer>();
        if (swat != null)
        {
            if (shield != null && player != null)
            {
                player.LoseHearts(damage);
            }
            else if (shield == null && player != null)
            {
                player.LoseHearts(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (preso != null)
        {
            animator.SetBool("Atizando", false);
        }
    }
}
