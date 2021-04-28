using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        HealthPlayer player = collision.GetComponent<HealthPlayer>();
        //Si colisiona con el jugador
        if (player != null)
        {
            player.LoseHearts(damage);
        }
    }

}
