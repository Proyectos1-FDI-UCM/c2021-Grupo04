using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int heartsRemaining;
    public Image[] hearts;
    public GameObject panelRefresco;
    public GameObject panelSandwich;
    public GameObject panelWhetstone;
   
    void Start()
    {
        GameManager.GetInstance().SetUIManager(this);
    }

    public void LoseHeart()
    {
        heartsRemaining--;

        hearts[heartsRemaining].enabled = false;

        if (heartsRemaining == 0)
        {
            Debug.Log("Has perdido");
        }
    }
    private void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            LoseHeart();
        }
    }

    public void PanelRefesco(bool active)
    {
        if (active)
        {
            panelRefresco.SetActive(true);
        }
        else
        {
            panelRefresco.SetActive(false);
        }
    }
    public void PanelSandwich(bool active)
    {
        if (active)
        {
            panelSandwich.SetActive(true);
        }
        else
        {
            panelSandwich.SetActive(false);
        }
    }

    public void PanelWhetstone(bool active)
    {
        if (active)
        {
            panelWhetstone.SetActive(true);
        }
        else
        {
            panelWhetstone.SetActive(false);
        }
    }


}


