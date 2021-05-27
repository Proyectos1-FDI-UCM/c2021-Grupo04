using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Miguel y Adrián

    //Botones del menu de pausa y de confirmación de salida
    public GameObject menuPanel, surePanel;
    public GameObject selectOptionsMenu;
    public GameObject selectControlsPanel;
    public GameObject gameOverPanel;
    void Start()
    {
        ContinueGame();
        gameOverPanel.SetActive(false);
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

    /// <summary>
    /// Hace visible el panel de Game Over que permite 
    /// reiniciar nivel o volver al menu principal
    /// </summary>
    public void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
        PauseGameTime();
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

    public void OpenOptionsMenu()
    {
        selectOptionsMenu.SetActive(true);
    }
    public void BackOptionsMenu()
    {
        selectOptionsMenu.SetActive(false);
    }
    public void OpenControlsPanel()
    {
        selectControlsPanel.SetActive(true);
    }
    public void CloseControlsPanel()
    {
        selectControlsPanel.SetActive(false);
    }
}
