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

    /// <summary>
    /// El enemigo sufre daño cuando la herropea colisiona con él
    /// este daño viene marcado por la variable damage
    /// </summary>
    /// <param name="damage">Daño actual que realiza le herropea</param>
    public void GetDamage(float damage)
    {
        Debug.Log("Daño sufrido: " + damage);
    }

}
