using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colchon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            GetComponentInChildren<Animator>().enabled = true;
            collision.GetComponent<Respawn>().Llegado(transform.position.x, transform.position.y);
        }
    }
}
