using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //Manu
    private NewPreso preso;
    // Start is called before the first frame update
    void Start()
    {
        preso = GetComponentInParent<NewPreso>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (preso.peacefull == true)
            preso.ChangeDir();
    }
}
