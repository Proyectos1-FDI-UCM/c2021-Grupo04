using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDamage : MonoBehaviour
{
    public float mulDamage = 1.5f;
     [SerializeField] Herropea herropea;
    private float orDamage;
    
        
    
    private void OnEnable()
    {
        orDamage = herropea.damage;
        herropea.damage = orDamage * mulDamage;
        Invoke("AfilatedStone", 10f);
       
        
    }

    public void AfilatedStone()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
       herropea.damage = orDamage;
        GameObject.GetInstance().WhetstoneAppears(false);
    }
}
