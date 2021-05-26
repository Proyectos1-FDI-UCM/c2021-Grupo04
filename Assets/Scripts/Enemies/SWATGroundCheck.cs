using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWATGroundCheck : MonoBehaviour
{
    SWAT swat;

    private void Start()
    {
        swat = GetComponentInParent<SWAT>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<CompositeCollider2D>() != null)
        {
            if (!swat.IsCharging())
            {
                swat.ChangeDir();
            }
        }
    }
}
