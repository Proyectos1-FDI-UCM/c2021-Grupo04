using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //relativo a inventario
    
    public GameObject panelRefresco;
    public GameObject panelSandwich;
    public GameObject panelWhetstone;
   
    //relativo a corazones
    private int heartsLeft;
    public RectTransform panelHearts;
    public Image heartsIconPrefab;
   
    void Start()
    {
        GameManager.GetInstance().SetUIManager(this);
        
    }

    public void DrawHearts(int numHearts)
    {
        heartsLeft = numHearts;
        
       for (int cont=0; cont < numHearts;cont++)
        {
            Instantiate(heartsIconPrefab, panelHearts);
            
        }
    }
    public void DrawHeartBySandwich()
    {
        Instantiate(heartsIconPrefab, panelHearts);
    }

    public void RemoveHeart()
    {
        if (heartsLeft >= 0)
        {
            if (panelHearts != null)
            {
                panelHearts.GetChild(heartsLeft - 1).gameObject.SetActive(false);
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


