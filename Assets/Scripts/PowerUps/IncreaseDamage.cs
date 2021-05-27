using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    //Adrián y Miguel
    public float mulDamage = 1.5f;
    public float disableDelay = 3f;
     [SerializeField] Herropea herropea;
    private float orDamage;
    
        
    //cogemos la variable de daño de herropea y la multiplicamos
    private void OnEnable()
    {
        herropea.MulDamage(mulDamage);
        Invoke("AfilatedStone", disableDelay);
       
        
    }

    public void AfilatedStone()
    {
        this.enabled = false;
    }
    //restablecemos daño
    private void OnDisable()
    {
        herropea.ResetDamage(mulDamage);
        GameManager.GetInstance().WhetstoneAppears(false);
    }
}
