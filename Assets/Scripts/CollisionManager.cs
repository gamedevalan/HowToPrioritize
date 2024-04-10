using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private Topping collidingTopping;
    private Vector3 collidingToppingPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ScenesManager.WhatSceneAmI() != "Tutorial Level") {
            collidingTopping = UsefulFunctions.WhatToppingAmI(collision.gameObject);
        }
        else
        {
            collidingTopping = UsefulFunctions.WhatToppingAmITutorial(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collidingToppingPos = collision.transform.position;
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (!Input.GetMouseButton(0))
        {
            SoundEffects.PlayPutDown();
            ApplyTopping.ApplyToppingToPizza(collidingTopping, collidingToppingPos, this.transform.position);
        }
    }


}
