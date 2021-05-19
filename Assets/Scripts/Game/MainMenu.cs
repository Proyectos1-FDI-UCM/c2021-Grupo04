using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    //Miguel y Adrián
    public GameObject selectScene;
    public GameObject selectOptionsMenu;
    public GameObject selectControlsPanel;

    private void Start()
    {
        BackMenu();
    }

    public void BackMenu()
    {
        selectScene.SetActive(false);
    }

    public void ActivateMenu()
    {
        selectScene.SetActive(true);
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
