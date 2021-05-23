using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySounds : MonoBehaviour
{
    //Adrián
    public float lifeTime;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
