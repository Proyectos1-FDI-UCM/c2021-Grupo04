using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject selectScene;

    private void Start()
    {
        BackMenu();
    }

    public void BackMenu()
    {
        selectScene.SetActive(false);
    }

    public void AcivateMenu()
    {
        selectScene.SetActive(true);
    }
}
