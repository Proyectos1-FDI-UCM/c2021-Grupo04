using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Adrián

    //relativo a inventario
    
    public GameObject panelRefresco;
    public GameObject panelSandwich;
    public GameObject panelWhetstone;
    public GameObject panelInfo;
    //relativo a corazones
    private int heartsLeft;
    public RectTransform panelHearts;
    public Image heartsIconPrefab;
    public Image leftHeartIcon;
    public Image rightHeartIcon;
    private PauseMenu pauseMenu;
   
    void Start()
    {
        GameManager.GetInstance().SetUIManager(this);
        Invoke("DisableInfoText", 8f);
    }
//para pintar los corazones
    public void DrawHearts(int numHearts)
    {
        heartsLeft = numHearts;
        
        for (int cont=0; cont < numHearts;cont++)
        {
            if (cont % 2 != 0) //si las vidas no son pares, instanciamos mitad derecha, si son pares, la mitad izquierda
            {
                Instantiate(rightHeartIcon, panelHearts);
            }
            else
            {
                Instantiate(leftHeartIcon, panelHearts);
            }
           
            
        }
    }
    //método auxiliar para el sándwich
    public void DrawHeartBySandwich()
    {
        if (heartsLeft % 2 != 0)
        {
            Instantiate(rightHeartIcon, panelHearts);
        }
        else
        {
            Instantiate(leftHeartIcon, panelHearts);
        }
        heartsLeft++;
    }
    //para borrar corazones
    public void RemoveHeart()
    {
        //si seguimos teniendo corazones, borramos el que está más a la derecha en panel hearts
        if (heartsLeft >= 0)
        {
            if (panelHearts != null)
            {
                Destroy(panelHearts.GetChild(heartsLeft - 1).gameObject);
                heartsLeft--;
            }
                
        }
    }

    public void ActivateGOPanel()
    {
        pauseMenu = GetComponent<PauseMenu>();
        pauseMenu.ActivateGameOverPanel();
    }
   
    //relativo a inventario
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


