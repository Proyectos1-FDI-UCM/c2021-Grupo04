using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private NewPreso scriptPreso;
    public GameObject preso;

    private void Start()
    {
        scriptPreso = GetComponentInParent<NewPreso>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            scriptPreso.Follow();
            Debug.Log("visto :)");
        }

    }
}
