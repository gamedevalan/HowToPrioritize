using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyTopping : MonoBehaviour
{
    public static void ApplyToppingToPizza(Topping topping, Vector3 currentPosition, Vector3 dough)
    {
        Vector3 destination = topping.isSpread? new Vector3(dough.x, dough.y, topping.zPosition): new Vector3(currentPosition.x, currentPosition.y, topping.zPosition);
        GameObject toppingOnPizzaHolder = GameObject.Find("Toppings On Pizza Holder");
        topping.onPizzaGameObjectClone = Instantiate(topping.onPizzaGameObject, destination, Quaternion.identity, toppingOnPizzaHolder.transform);
        if (ScenesManager.WhatSceneAmI() != "Tutorial Level") {
            topping.onPizzaGameObjectClone.GetComponent<DraggableOnTrash>().SetDraggable(true);
        }
        else
        {
            topping.onPizzaGameObjectClone.GetComponent<DraggableOnTrashTutorial>().SetDraggable(true);
        }
        topping.IncrementCounter();
    }

}
