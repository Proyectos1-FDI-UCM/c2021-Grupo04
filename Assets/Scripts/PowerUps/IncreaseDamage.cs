using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    public float mulDamage = 1.5f;
    public float disableDelay = 3f;
     [SerializeField] Herropea herropea;
    private float orDamage;
    
        
    
    private void OnEnable()
    {
        herropea.MulDamage(mulDamage);
        Invoke("AfilatedStone", disableDelay);
       
        
    }

    public void AfilatedStone()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
        herropea.ResetDamage(mulDamage);
        GameManager.GetInstance().WhetstoneAppears(false);
    }
}
