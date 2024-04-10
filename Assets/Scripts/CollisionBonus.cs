using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBonus : MonoBehaviour
{
    private BonusDragOnPizza collidingTopping;
    private Vector3 collidingToppingPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collidingTopping = collision.gameObject.GetComponent<BonusDragOnPizza>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        collidingToppingPos = collision.transform.position;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (Input.GetMouseButton(0))
        {
        }
        else
        {
            SoundEffects.PlayPutDown();

            Vector3 dough = this.transform.position;
            Vector3 destination = collidingTopping.isSpread? new Vector3(dough.x, dough.y, 0) : new Vector3(collidingToppingPos.x, collidingToppingPos.y, 0);
            GameObject toppingOnPizzaHolder = GameObject.Find("Toppings On Pizza Holder");
            GameObject onPizzaGameObjectClone = Instantiate(collidingTopping.onPizzaGameObject, destination, Quaternion.identity, toppingOnPizzaHolder.transform);
        }
    }


}
