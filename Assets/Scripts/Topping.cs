using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Topping
{
    public string toppingName { get; }
    public string toppingTask { get; }
    public GameObject onTableGameObject { get; }
    public GameObject onPizzaGameObject { get; }
    public float zPosition { get; }
    public int counter{ get; set; }
    public bool isSpread { get; }
    public GameObject onPizzaGameObjectClone { get; set; }
    public int goal { get; }

    //constructor
    public Topping(GameObject onTableGameObject, GameObject onPizzaGameObject, string toppingName, string toppingTask, float zPosition, bool isSpread)
    {
        this.onTableGameObject = onTableGameObject;
        this.onPizzaGameObject = onPizzaGameObject;
        this.toppingName = toppingName;
        this.toppingTask = toppingTask;
        this.zPosition = zPosition;
        this.isSpread = isSpread;
        counter = 0;
    }

    public void IncrementCounter()
    {
        counter++;
    }

    public void DecrementCounter()
    {
        counter--;
    }


}
