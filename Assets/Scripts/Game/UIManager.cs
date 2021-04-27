using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int heartsRemaining;
    public Image[] hearts;
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


}


