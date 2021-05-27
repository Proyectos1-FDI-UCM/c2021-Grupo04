// ----------------------------------------------------------
// Gestión de power-ups (II)
// Motores de Videojuegos - FDI - UCM
// ----------------------------------------------------------
// Profesores: Marco Antonio Gómez Martín
//             Eva Ullán
// ----------------------------------------------------------

using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// Componente pensado para ser añadido al jugador para gestionar
/// sus power-ups.
/// </summary>
/// Cada power-up es implementado con un componente distinto.
/// Un power-up estará habilitado si su componente está activado.
/// Por lo tanto, todos los componentes que implementan power-ups
/// estarán deshabilitados desde el principio.
/// Este componente (en el jugador) añade un método ActivatePowerUp(string)
/// que recibe el nombre del power-up a activar (debe coincidir con
/// el nombre del componente) y lo activa. Si había un power-up previo
/// activo, lo desactiva.
public class PowerUpManager : MonoBehaviour
{
    //Adrián y Manu
    MonoBehaviour currentPowerUp;
    public AudioSource soundPowerUp;

   
    public void ActivatePowerUp(string powerUpName)
    {

        // Localiza el componente powerUpName asociado 

        MonoBehaviour powerUp = GetComponent(powerUpName) as MonoBehaviour;


        if (powerUp == null)
        {
            Debug.Log("Componente power-up " + powerUpName + " no encontrado. Se ignora.");
            return;
        }

        if (currentPowerUp != null)
            // Desactiva el power-up activo
            currentPowerUp.enabled = false;

        // Activa el power-up indicado
        powerUp.enabled = true;
        currentPowerUp = powerUp;

        Debug.Log("Componente power-up " + powerUpName + " activado.");
        soundPowerUp.Play();

    }
}

