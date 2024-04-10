using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulFunctions
{
    //pass in a gameobject and returns which topping that game object is associated with.
    public static Topping WhatToppingAmI(GameObject gameObject)
    {
        foreach (Topping t in Main.toppings)
        {
            if (gameObject.Equals(t.onTableGameObject) || gameObject.Equals(t.onPizzaGameObject) || gameObject.Equals(t.onPizzaGameObjectClone))
            {
                return t;
            }
        }
        return null;
    }

    public static bool IsThisOnThat(GameObject thisGO, GameObject thatGO)
    {
            if ((Mathf.Abs(thisGO.transform.localPosition.x - thatGO.transform.localPosition.x) <= 3f) &&
                (Mathf.Abs(thisGO.transform.localPosition.y - thatGO.transform.localPosition.y) <= 3f))
            {
                return true;
            }
            else
            {
                return false;
            }
    }

    public static void SetIfToppingDraggable(bool val)
    {
        foreach (GameObject t in Main.toppingTableObjects)
        {
            t.GetComponent<DraggableOnPizza>().SetDraggable(val);
        }
        Transform toppingOnPizzaHolder = GameObject.Find("Toppings On Pizza Holder").transform;
        for (int i = 0; i < toppingOnPizzaHolder.childCount; i++)
        {
            toppingOnPizzaHolder.GetChild(i).GetComponent<DraggableOnTrash>().SetDraggable(val);
        }
    }

    public static void SetToppingDraggable(string topping)
    {
        foreach (GameObject t in Main.toppingTableObjects)
        {
            if (t.name.Contains(topping)) {
                t.GetComponent<DraggableOnPizza>().SetDraggable(true);
                return;
            }
        }
    }

    // For the tutorial only
    //pass in a gameobject and returns which topping that game object is associated with.
    public static Topping WhatToppingAmITutorial(GameObject gameObject)
    {
        foreach (Topping t in MainTutorial.toppings)
        {
            if (gameObject.Equals(t.onTableGameObject) || gameObject.Equals(t.onPizzaGameObject) || gameObject.Equals(t.onPizzaGameObjectClone))
            {
                return t;
            }
        }
        return null;
    }

    public static bool IsThisOnThatTutorial(GameObject thisGO, GameObject thatGO)
    {
        if ((Mathf.Abs(thisGO.transform.localPosition.x - thatGO.transform.localPosition.x) <= 3f) &&
            (Mathf.Abs(thisGO.transform.localPosition.y - thatGO.transform.localPosition.y) <= 3f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void SetIfToppingDraggableTutorial(bool val)
    {
        foreach (GameObject t in MainTutorial.toppingTableObjects)
        {
            t.GetComponent<DraggableOnPizzaTutorial>().SetDraggable(val);
        }
        Transform toppingOnPizzaHolder = GameObject.Find("Toppings On Pizza Holder").transform;
        for (int i = 0; i < toppingOnPizzaHolder.childCount; i++)
        {
            toppingOnPizzaHolder.GetChild(i).GetComponent<DraggableOnTrashTutorial>().SetDraggable(val);
        }
    }

    public static void SetToppingDraggableTutorial(string topping)
    {
        foreach (GameObject t in MainTutorial.toppingTableObjects)
        {
            if (t.name.Contains(topping))
            {
                t.GetComponent<DraggableOnPizzaTutorial>().SetDraggable(true);
                return;
            }
        }
    }
}
