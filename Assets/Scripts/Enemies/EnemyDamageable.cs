using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    //Miguel, Edu(animación sangre)
    /*Script asociado a los enemigos que detecta si la bola ha colisionado con el.
     * Para evitar errores a la hora de hacer daño a los enemigos, se pretende que la detección del
     * ataque solo sea posible cuando Makt Fange lanza la bola
     */
    // Start is called before the first frame update
    public int life = 30;
    public float impulseAfterDamageX = 0.2f;
    public float impulseAfterDamageY = 0.2f;
    public UnityEngine.GameObject whetstone;
    public UnityEngine.GameObject sandwich;
    public UnityEngine.GameObject refresco;
    public int probDrop = 7;

    private float health;
    public GameObject sangre;
    Rigidbody2D rb;
    ChangeColor color;
    NewPerro perro;
    SWAT swat;
    private void Start()
    {
        health = life;
        rb = GetComponent<Rigidbody2D>();
        perro = GetComponent<NewPerro>();
        swat = GetComponent<SWAT>();
        if (swat != null || perro != null)
        {
            color = GetComponentInChildren<ChangeColor>();
        }
        else
        {
            color = GetComponent<ChangeColor>();
        }
    }

    private void Update()
    {
        if(rb.velocity.x > 0)
        {
            Invoke("Stop", 0.2f);
        }
    }
    /// <summary>
    /// El enemigo sufre daño cuando la herropea colisiona con él
    /// este daño viene marcado por la variable damage
    /// </summary>
    /// <param name="damage">Daño actual que realiza le herropea</param>
    public void GetDamage(float damage)
    {
        health -= damage;
        color.CambiaColor();
        
        //rb.AddForce(new Vector2(impulseAfterDamageX, impulseAfterDamageY));
        if (health <= 0)
        {
            Instantiate(sangre, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            SpawnPowerUp();
        }
    }
    public void SpawnPowerUp()
    {    
        // numero aleatorio que determina las probabilidades de que el enemigo suelte un drop
        int drop = Random.Range(1, 10);

        if(drop<probDrop)
        {
            // numero aleatorio que determina que drop va a soltar el enemigo
            int whatDrop = Random.Range(1, 3);
            Debug.Log(whatDrop);
            if (whatDrop == 1)
            {
                Instantiate(refresco, transform.position, transform.rotation);
            }
            else if (whatDrop == 2) 
            {
                Instantiate(whetstone, transform.position, transform.rotation);
            }
            else Instantiate(sandwich, transform.position, transform.rotation);
        }
    }
}
