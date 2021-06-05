using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Adrián,Manuel y Miguel
    public string menu;
    
    public int sandwich = 1;
    public enum powerUp { IncreaseDamage, Sandwich, ExtraVelocity, Empty }
    public powerUp myPowerUp = powerUp.Empty;
    private UIManager theUIManager;
    private static GameManager instance;
    private int returnLives = 8;
    PowerUpManager pum;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }     
    }

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
        
       
    }
    
    public void ReDrawHearts(int lives)
    {
        
        theUIManager.DrawHearts(lives);
    }
    
    public void AddOneHeartBySandwich()
    {
        theUIManager.DrawHeartBySandwich();
    }

    // Metodo para cambiar el powerUp activo del inventario
    public void ChangePowerUp(string newPowerUp, PowerUpManager pum1)
    {
        pum = pum1;
        // si el powerUp está vacío se selecciona el nuevo y se muestra en el hud
        if (myPowerUp == powerUp.Empty)
        {
            if (newPowerUp == "IncreaseDamage")
            {
                myPowerUp = powerUp.IncreaseDamage;
            }
            else if (newPowerUp == "Sandwich")
            {
                myPowerUp = powerUp.Sandwich;   
            }
            else if (newPowerUp == "ExtraVelocity")
            {
                myPowerUp = powerUp.ExtraVelocity;                
            }
            else Debug.Log("nombre erroneo de power up");
            PowerUpAppears(true);
        }
    }
    // metodo que llama al powerUp manager para activar el powerUp
    public void ActivatePowerUp()
    {
        string newPowerUp;

        if (!IsEmpty())
        {           
            newPowerUp = myPowerUp.ToString();
            PowerUpAppears(false);
            pum.ActivatePowerUp(newPowerUp);
            myPowerUp = powerUp.Empty;
        }
    }
    // metodo que devuelve true si el powerUp está vacío
    public bool IsEmpty()
    {          
        return (myPowerUp==powerUp.Empty);
    }

    // Metodo que detecta que powerUp está activo 
    public void PowerUpAppears(bool active)
    {
        if (myPowerUp == powerUp.IncreaseDamage)
        {
            theUIManager.PanelWhetstone(active);
            
        }
        else if (myPowerUp == powerUp.Sandwich)
        {
            theUIManager.PanelSandwich(active);
        }
        else if (myPowerUp == powerUp.ExtraVelocity)
        {
            theUIManager.PanelRefesco(active);
        }
        Debug.Log(active);
        Debug.Log(myPowerUp);
    }

    public void HeartDestroyed()
    {
        theUIManager.RemoveHeart();
        
    }

    //Activamos power up para segurar que se vacía entre escenas
    public void ChangeScene(int scene)
    {
        //Activamos el power up para vaciar su contenido
        ActivatePowerUp();
        SceneManager.LoadScene(scene);
    }

    //carga la siguiente escena de la Build
    public void ChargeNextScene()
    {
        //Activamos el power up para vaciar su contenido
        ActivatePowerUp();
        ChangeScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ChargeMenu()
    {
        ActivatePowerUp();
        ChangeScene(1);
    }

    public void ActivateGameOverPanel()
    {
        ActivatePowerUp();
        theUIManager.ActivateGOPanel();
    }

    public void RestartScene()
    {
        ActivatePowerUp();
        ChangeScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int ActualSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void SaveLives(int lives)
    {
        returnLives = lives;
    }

    public int ReturnLivesBetweenScenes()
    {
        return returnLives;
    }

    //para detener ejecución de Unity
    public void ExitGame()
    {
     #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     #else
        Application.Quit();
     #endif
    }

   

}
