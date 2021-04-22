using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    /*Script asociado a los enemigos que detecta si la bola ha colisionado con el.
     * Para evitar errores a la hora de hacer daño a los enemigos, se pretende que la detección del
     * ataque solo sea posible cuando Makt Fange lanza la bola
     */
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Herropea herropea = collision.GetComponent<Herropea>();
        if (herropea != null)
        {
            if (herropea.LanzamientoForzoso())
            {
                Debug.Log("Enemigo dañado por la herropea");
            }
        }
    }

}
