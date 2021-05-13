using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Botones del menu de pausa y de confirmación de salida
    public GameObject menuPanel, surePanel;

    void Start()
    {
        ContinueGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!menuPanel.activeSelf)
            {
                menuPanel.SetActive(true);
            }
            else if (menuPanel.activeSelf && !surePanel.activeSelf)
            {
                menuPanel.SetActive(false);
            }  
            else if (surePanel.activeSelf)
            {
                DontQuit();
            }
        }
    }

     public void ContinueGame()
     {
        menuPanel.SetActive(false);
        surePanel.SetActive(false);
     }

    public void ExitMenu()
    {
        surePanel.SetActive(true);
    }

    public void DontQuit()
    {
        surePanel.SetActive(false);
    }

    public void GoBackToMainMenu()
    {
        GameManager.GetInstance().ChargeMenu();
    }
}
