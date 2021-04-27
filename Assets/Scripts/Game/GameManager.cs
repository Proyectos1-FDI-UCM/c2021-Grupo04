using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public int lives = 8;
    public int sandwich = 2;
    private UIManager theUIManager;
    private static GameManager instance;
    enum powerUp { IncreaseDamage, Sandwich, ExtraVelocity, Empty }
    powerUp myPowerUp = powerUp.Empty;
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

    public void LoseHearts(int damage)
    {
        Debug.Log("Daño sufrido por el jugador " + damage);              
        lives -= damage;       
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
                myPowerUp = powerUp.IncreaseDamage;
            else if (newPowerUp == "Sandwich")
                myPowerUp = powerUp.Sandwich;
            else if (newPowerUp == "ExtraVelocity")
                myPowerUp = powerUp.ExtraVelocity;
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
                newPowerUp = "IncreaseDamage";
            else if (myPowerUp == powerUp.Sandwich)
                newPowerUp = "Sandwich";
            else if (myPowerUp == powerUp.ExtraVelocity)
                newPowerUp = "ExtraVelocity";

            myPowerUp = powerUp.Empty;
            pum.ActivatePowerUp(newPowerUp);
        }
    }


}
