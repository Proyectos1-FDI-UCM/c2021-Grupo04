using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClavado : MonoBehaviour
{
    public DestroyFakeHerropea fakeHerropea;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<RightTriggerWall>() || collision.gameObject.GetComponent<LeftTriggerWall>())
        {
            fakeHerropea.SetCollider();           
        }
    }

}
