using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private Transform destination;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(origin.position, 0.1f);
        Gizmos.DrawSphere(destination.position, 0.1f);
    }
}
