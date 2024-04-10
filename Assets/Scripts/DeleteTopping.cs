using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTopping : MonoBehaviour
{
    public static void DeleteToppingOnPizza(GameObject gameObjectToDestroy, Topping topping)
    {
        Destroy(gameObjectToDestroy);
        if (topping != null) {
            topping.DecrementCounter();
        }
    }
}
