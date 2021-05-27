using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herropea : MonoBehaviour
{
    //Miguel
    public float velLanzamiento = 5;
    public float gravity = 1;
    public float maxDistance;
    public float damage = 15;
    public float emergeVelocity = 1;
    public float velocidadRecogida = 0.3f;

    public Transform pickUpPosition;
    public Transform chainZone;
    public Transform scenario;

    public Rigidbody2D rbMakt;

    public GameObject maktFange;
    public GameObject recogerCadena;
    public GameObject soltarHerropea;

    [SerializeField] private float distance; //Distancia bola jugador

    private bool agarrando = false; //Si Makt Fange esta agarrando la bola
    private bool flotando = true; //True si es afectada por la gravedad
    private bool lanzamiento = false; //Si la bola está viajando por un lanzamento de Makt Fange
    private bool clavado = false; //True cuando hay una herropea falsa instanciada a la que subirse
    private bool wallContact = false;

    private PlayerController playerController;
    private DestroyFakeHerropea scriptFakeHerropea;

    //Variables para inhibilitar el movimiento de Makt Fange
    private bool dontMoveRight = false;
    private bool dontMoveLeft = false;

    private void Start()
    {
        scriptFakeHerropea = GetComponentInChildren<DestroyFakeHerropea>();
        playerController = maktFange.GetComponent<PlayerController>();
        Invoke("SetTransformHerropea", 0.05f);
    }

    void Update()
    {
        float step = rbMakt.velocity.sqrMagnitude * Time.deltaTime;

        //Guardamos la distancia entre Makt y la herropea
        distance = Vector2.Distance(chainZone.transform.position, transform.position);
        
        if(!wallContact && !lanzamiento)
        {
            transform.right = maktFange.transform.right;
        }

        if (distance >= maxDistance)
        {
            //La herropea se mueve hacia el jugador a la misma velocidad que él
            transform.position = Vector2.MoveTowards(transform.position, chainZone.transform.position, step);
        }
    
        // El jugador agarra la herropea si no lo está haciendo ya y si el jugador está quieto
        if (Input.GetButton("Jump") && !agarrando && playerController.Salto())
        {
            Instantiate(recogerCadena);
            //Animamoss al personaje y recogemos herropea
            playerController.SetPickUpAnimation(true);
            transform.position = Vector2.MoveTowards(transform.position, chainZone.transform.position, velocidadRecogida * Time.deltaTime);
            if (transform.position == chainZone.transform.position)
            {
                playerController.SetPickUpAnimation(false);
                agarrando = true;
                transform.position = new Vector3(pickUpPosition.position.x, pickUpPosition.position.y);
                transform.SetParent(pickUpPosition);
                transform.rotation = transform.parent.rotation;
                playerController.SetMovRight(true);
                playerController.SetMovLeft(true);
            }
        }
        // El jugador deja de agarrar la herropea con shift
        else if (Input.GetButton("Fire3"))
        {
            Instantiate(soltarHerropea);
            agarrando = false;
            transform.SetParent(scenario);
        }
        //El jugador lanza si está agarrando y pulsa ctrl
        else if (Input.GetButtonDown("Fire1") && agarrando)
        {           
            Debug.Log("Lanzamiento");                   
            lanzamiento = true;
            transform.SetParent(scenario);
        }
        else playerController.SetPickUpAnimation(false);

        //Siempre que no esté agarrando Fange la bola y que el bool floating sea true, le afecta la gravedad
        if (!agarrando && flotando)
        {
            transform.Translate(Vector2.down * gravity * Time.deltaTime);
        }       

        //La herropea avanza si Makt Fange usa su ataque Lanzamiento Forzoso
        if (lanzamiento)
        {           
            transform.Translate(Vector2.right * velLanzamiento * Time.deltaTime);
            if (distance >= maxDistance) 
            {
                lanzamiento = false;
                transform.SetParent(scenario);
                agarrando = false;             
            }
        }

        //Codigo defensivo para evitar que el collider esté activo cuando la herropea no esté clavada
        if (scriptFakeHerropea.IsColliderSet() && !clavado)
        {
            Debug.LogWarning("Bug del collider FakeHerropea salvado");
            scriptFakeHerropea.DisableCollider();
        }

        CheckIfPlayerCanMove();

        if(wallContact && !clavado)
        {
            clavado = true;
        }

        //Comprobamos que la herropea se clave
        if (clavado)
        {
            scriptFakeHerropea.SetCollider();
        }
    }

    public void SetTransformHerropea()
    {
        transform.position = new Vector2(chainZone.position.x + 1, chainZone.position.y);
        
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        //La gravedad vuelve a afectar a la herropea al colisionar con el tilemap o con el policía
        if(collision.GetComponent<CompositeCollider2D>() != null)
        {
            Debug.Log("Flotando");
            flotando = true;
            if (clavado)
            {
                scriptFakeHerropea.DisableCollider();
                clavado = false;
            }           
        }      
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Guardamos la referencia del enemigo en una variable para acceder luego a un método suyo
        EnemyDamageable enemigo = collision.GetComponent<EnemyDamageable>();

        if (collision.GetComponent<CompositeCollider2D>() != null)
        {
            if (lanzamiento)
            {                
                clavado = true;                
                lanzamiento = false;
                agarrando = false;            
            }
            flotando = false; //Deja de afectarle la gravedad
            Debug.Log("Suelo");
            //Si además la bola ha sido lanzada por MaktFange, se queda clavada en la pared   
            
        }
        else if (enemigo && collision.GetComponent<Shield>() == null && collision.GetComponent<SWAT>() == null)
        {
            if (lanzamiento)
            {
                enemigo.GetDamage(damage);
                lanzamiento = false;
                agarrando = false;
            }
        }

        if(clavado)
        {
            scriptFakeHerropea.SetCollider();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Shield>() != null || collision.GetComponent<SWAT>() != null)
        {
            if (lanzamiento)
            {
                collision.GetComponent<EnemyDamageable>().GetDamage(damage);
                lanzamiento = false;
                agarrando = false;
                if (collision.GetComponent<SWAT>() != null && ((collision.transform.localScale.x > 0 && this.transform.position.x < collision.transform.position.x) 
                    || (collision.transform.localScale.x < 0 && this.transform.position.x > collision.transform.position.x)))
                {
                    collision.GetComponent<SWAT>().ChangeDir();
                }
            }
        }
    }

    public void SetWallContact(bool triggered)
    {
        wallContact = triggered;
        clavado = triggered;
    }

    public bool AgarrandoHerropea()
    {
        return agarrando;
    }

    public bool Lanzamiento()
    {
        return lanzamiento;
    }
    
    public float GetDistanceHerropea()
    {
        return distance;
    }

    public float GetMaxDistance()
    {
        return maxDistance;
    }

    public void MulDamage(float mulDamage)
    {
        damage *= mulDamage;
        Debug.Log("Daño actual de la herropea" + damage);
    }

    public void ResetDamage(float mulDamage)
    {
        damage /= mulDamage;
        Debug.Log("Daño actual de la herropea" + damage);
    }

    public void DontMoveRight()
    {
        dontMoveRight = true;
    }

    public void DontMoveLeft()
    {
        dontMoveLeft = true;
    }

    public void MoveRight()
    {
        dontMoveRight = false;
    }

    public void MoveLeft()
    {
        dontMoveLeft = false;
    }

    /// <summary>
    /// Comprueba si los triggers de la herropea estan en contacto con un muro y
    /// permite o impide el movimiento del jugador en función del trigger en contacto.
    /// </summary>
    public void CheckIfPlayerCanMove()
    {
        if (wallContact && distance > (maxDistance - 0.36f))
        {
            if (dontMoveRight && !dontMoveLeft)
            {
                playerController.SetMovRight(false);
                playerController.SetMovLeft(true);
            }
            else if (!dontMoveRight && dontMoveLeft)
            {
                playerController.SetMovRight(true);
                playerController.SetMovLeft(false);
            }
            else
            {
                playerController.SetMovRight(false);
                playerController.SetMovLeft(false);
            }
        }
        else
        {
            playerController.SetMovRight(true);
            playerController.SetMovLeft(true);
        }
    }
}
