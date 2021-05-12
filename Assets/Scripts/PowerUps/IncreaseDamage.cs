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
        Debug.Log("Daño actual de la herropea: " + herropea.damage);
        
    }

    public void AfilatedStone()
    {
        this.enabled = false;
    }

    private void OnDisable()
    {
       herropea.damage = orDamage;
        GameManager.GetInstance().WhetstoneAppears(false);
    }
}
