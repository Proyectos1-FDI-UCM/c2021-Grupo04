﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFakeHerropea : MonoBehaviour
{
    CircleCollider2D circleCollider;
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public void SetCollider()
    {
        circleCollider.enabled = !circleCollider.enabled;
    }
}