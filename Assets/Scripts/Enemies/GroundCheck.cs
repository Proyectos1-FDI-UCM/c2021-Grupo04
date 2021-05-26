﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Manu
    private NewPreso preso;
    private SWAT swat;
    // Start is called before the first frame update
    void Start()
    {
        preso = GetComponentInParent<NewPreso>();
        swat = GetComponentInParent<SWAT>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (preso != null && preso.peacefull == true)
        {
            preso.ChangeDir();
        }
        else if(swat != null)
        {
            swat.ChangeDir();
        }
    }
}
