// ----------------------------------------------------------
// Gestión de power-ups (I)
// Motores de Videojuegos - FDI - UCM
// ----------------------------------------------------------
// Profesores: Marco Antonio Gómez Martín
//             Eva Ullán
// ----------------------------------------------------------

using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Componente utilizado para activar power-ups del jugador
/// cuando el objeto al que pertenecemos colisiona con él.
/// </summary>
/// Permite configurar el nombre del power-up (que coincidirá
/// con el nombre del componente que lo implementa).
/// 
/// El GameObject debería pertenecer a una capa física
/// que únicamente colisiona con el jugador. Si el componente
/// detecta una colisión con cualquier cosa que no sea el
/// jugador (capa física "Player"), dará un aviso y no hará
/// nada.
/// Para funcionar el GameObject del jugador debe tener
/// el componente que gestiona los power-ups (PowerUpManager)
public class ActivatePowerUpOnCollision : MonoBehaviour
{
    //Manu y Adri
    [SerializeField]
    string powerUpName = null;

    int playerLayer;
    

    void Start()
    {

        if (powerUpName == null)
        {
            Debug.Log("Olvidaste configurar el nombre del power-up, así que me desactivo.");
            this.enabled = false;
        }
        else
        {
            // Identificador de la capa física "Player"
            playerLayer = LayerMask.NameToLayer("Player");
        }
        
    }

    void OnTriggerEnter2D(Collider2D info)
    {

        UnityEngine.GameObject other = info.gameObject;

        if (other.layer != playerLayer)
        {
            Debug.Log("Un power-up se ha chocado con algo distinto al jugador."
                + " Debes tener mal la configuración de las capas de colisión.");
            return;
        }

        PowerUpManager pum = other.GetComponent<PowerUpManager>();
       
        if (GameManager.GetInstance().IsEmpty())
        {
            

            if (pum == null)
            {
                Debug.Log("Jugador sin gestor de power-ups."
                + " Se ignora el power-up conseguido.");
            }
            else
            {
                GameManager.GetInstance().ChangePowerUp(powerUpName, pum);
                 
            }
            
            this.gameObject.SetActive(false);
            
        }
    }

}
