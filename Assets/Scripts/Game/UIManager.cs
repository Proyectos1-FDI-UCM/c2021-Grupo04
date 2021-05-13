using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Adrián

    //relativo a inventario
    
    public UnityEngine.GameObject panelRefresco;
    public UnityEngine.GameObject panelSandwich;
    public UnityEngine.GameObject panelWhetstone;
   
    //relativo a corazones
    private int heartsLeft;
    public RectTransform panelHearts;
    public Image heartsIconPrefab;
    public Image leftHeartIcon;
    public Image rightHeartIcon;
   
    void Start()
    {
        GameObject.GetInstance().SetUIManager(this);
        
    }

    public void DrawHearts(int numHearts)
    {
        heartsLeft = numHearts;
        
       for (int cont=0; cont < numHearts;cont++)
        {
            if (cont % 2 != 0)
            {
                Instantiate(rightHeartIcon, panelHearts);
            }
            else
            {
                Instantiate(leftHeartIcon, panelHearts);
            }
           
            
        }
    }
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

    public void RemoveHeart()
    {
        if (heartsLeft >= 0)
        {
            if (panelHearts != null)
            {
                Destroy(panelHearts.GetChild(heartsLeft - 1).gameObject);
                heartsLeft--;
            }
                
        }
    }
    private void Update()
    {
        
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


