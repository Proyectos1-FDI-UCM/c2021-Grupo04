using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager theUIManager;
    public int lives = 3;
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

    public void LoseHearts()
    {
        lives--;
       
    }

    public void EatSandwich()
    {
        lives++;
    }
}
