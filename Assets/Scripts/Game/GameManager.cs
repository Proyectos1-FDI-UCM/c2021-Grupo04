using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public int lives = 8;
    public int sandwich = 2;

    private UIManager theUIManager;
    private static GameManager instance;

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
        lives -= damage;       
    }

    public void EatSandwich()
    {
        lives += sandwich;
    }
}
