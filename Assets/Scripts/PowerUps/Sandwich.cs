using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandwich : MonoBehaviour
{
    public int extraHeart = 2;
    private void OnEnable()
    {
        GameManager.GetInstance().EatSandwich(extraHeart);
 
    }

    private void OnDisable()
    {
        GameManager.GetInstance().SandwichAppears(false);
    }
}
