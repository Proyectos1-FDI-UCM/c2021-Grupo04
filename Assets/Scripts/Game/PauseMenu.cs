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
                PauseGameTime();
            }
            else if (menuPanel.activeSelf && !surePanel.activeSelf)
            {
                ContinueGame();
            }  
            else if (surePanel.activeSelf)
            {
                DontQuit();
            }
        }
    }

    public void PauseGameTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGameTime()
    {
        Time.timeScale = 1f;
    }

    //Oculta el menu y despausa el juego
    public void ContinueGame()
    {
       menuPanel.SetActive(false);
       surePanel.SetActive(false);
       ResumeGameTime();
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
