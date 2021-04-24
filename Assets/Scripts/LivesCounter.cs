using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCounter : MonoBehaviour
{
    public int heartsRemaining;
    public Image[] hearts;

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoseHeart();
        }
    }
}
