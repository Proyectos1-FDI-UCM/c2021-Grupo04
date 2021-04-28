using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public int lives = 8;
    public int sandwich = 2;
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

    public void EatSandwich()
    {
        lives += sandwich;
    }

    public void ChangePowerUp(string newPowerUp, PowerUpManager pum1)
    {
        pum = pum1;
        if (myPowerUp == powerUp.Empty)
        {
            if (newPowerUp == "IncreaseDamage")
            {
                myPowerUp = powerUp.IncreaseDamage;
                WhetstoneAppears(true);

            }
            else if (newPowerUp == "Sandwich")
            {
                myPowerUp = powerUp.Sandwich;
                SandwichAppears(true);
            }
            else if (newPowerUp == "ExtraVelocity")
            {
                myPowerUp = powerUp.ExtraVelocity;
                RefrescoAppears(true);
            }
            else Debug.Log("nombre erroneo de power up");

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
            if (myPowerUp == powerUp.IncreaseDamage)
            {
                newPowerUp = "IncreaseDamage";
                WhetstoneAppears(false);
            }
            else if (myPowerUp == powerUp.Sandwich)
            {
                newPowerUp = "Sandwich";
                SandwichAppears(false);
            }
            else if (myPowerUp == powerUp.ExtraVelocity)
            {
                newPowerUp = "ExtraVelocity";
                RefrescoAppears(false);
            }

            myPowerUp = powerUp.Empty;
            pum.ActivatePowerUp(newPowerUp);
        }
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


}
