using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFakeHerropea : MonoBehaviour
{
    //Miguel y Manuel
    CircleCollider2D circleCollider;
    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        transform.localPosition = new Vector3(0, 0, 0);
    }

    public void SetCollider(bool collisionable)
    {
        circleCollider.enabled = collisionable;
    }

    /// <summary>
    /// Devuelve true si el collider esta activado, false en otro caso
    /// </summary>
    /// <returns></returns>
    public bool IsColliderSet()
    {
        return circleCollider.enabled;
    }
}
