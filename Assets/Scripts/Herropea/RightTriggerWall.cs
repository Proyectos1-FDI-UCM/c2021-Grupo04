//Trigger del lado derecha de la herropea
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTriggerWall : MonoBehaviour
{
    //Miguel
    Herropea herropea;

    private void Start()
    {
        herropea = GetComponentInParent<Herropea>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() != null)
        {
            //Avisa a Herropea de que está en contacto con ningún muro
            herropea.SetWallContact(true);
            herropea.DontMoveRight();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CompositeCollider2D>() != null)
        {
            //Avisa a Herropea de que no está en contacto con ningún muro
            herropea.SetWallContact(false);
            herropea.MoveRight();
        }
    }
}
