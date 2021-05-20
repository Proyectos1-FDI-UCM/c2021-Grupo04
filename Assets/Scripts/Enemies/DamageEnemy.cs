using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int damage = 1;

    SWAT swat;
    Shield shield;
    NewPreso preso;
    public Animator animator;

    private void Start()
    {
        swat = GetComponent<SWAT>();
        preso = GetComponentInParent<NewPreso>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        shield = GetComponent<Shield>();

        HealthPlayer player = collision.GetComponent<HealthPlayer>();
        if (swat != null)
        {
            if(shield != null && player != null)
            {
                player.LoseHearts(damage * 3);
            }
            else if(shield == null && player != null)
            {
                player.LoseHearts(damage * 2);
            }
        }
        else if (preso != null)
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (preso != null)
        {
            animator.SetBool("Atizando", false);
        }
    }
}
