using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    private void OnEnable()
    {
        GameManager.GetInstance().EatSandwich();

        
    }
}
