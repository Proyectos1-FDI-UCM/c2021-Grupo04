﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject, 0);
    }
}
