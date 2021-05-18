using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject selectScene;
    public GameObject selectOptionsMenu;

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
}
