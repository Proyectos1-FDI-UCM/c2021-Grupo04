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

    public void ChangePowerUp(string newPowerUp, PowerUpManager pum1)
    {
        pum = pum1;
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
        else Debug.Log("no hay hueco en el inventario");

        Debug.Log(myPowerUp);
    }
    public void ActivatePowerUp()
    {
        string newPowerUp = "Empty";
        if (myPowerUp == powerUp.Empty)
        {
            Debug.Log("no hay power up");
        }
        else
        {
            
            newPowerUp = myPowerUp.ToString();
            PowerUpAppears(false);
            pum.ActivatePowerUp(newPowerUp);
            myPowerUp = powerUp.Empty;
        }
           
        Debug.Log("g");
        
    }
    public bool IsEmpty()
    {          
        return (myPowerUp==powerUp.Empty);
    }

    public void RefrescoAppears(bool active)
    {
        theUIManager.PanelRefesco(active);

    }
    public void SandwichAppears(bool active)
    {
        theUIManager.PanelSandwich(active);

    }
    public void WhetstoneAppears(bool active)
    {
        theUIManager.PanelWhetstone(active);

    }
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

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        //Activamos el power up para vaciar su contenido
        ActivatePowerUp();
    }

    public void ChargeMenu()
    {
        ChangeScene(menu);
    }

    public void ActivateGameOverPanel()
    {
        theUIManager.ActivateGOPanel();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
