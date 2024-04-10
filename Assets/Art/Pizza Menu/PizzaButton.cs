using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PizzaButton : MonoBehaviour
{
    Vector2 defaultPos;

    void Start()
    {
        this.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        defaultPos = this.transform.GetChild(0).localPosition;
    }

    public void MoveStart()
    {
        this.transform.GetChild(0).localPosition = new Vector2(defaultPos.x + 70, 0);
    }

    public void MovePoints()
    {
        this.transform.GetChild(0).localPosition = new Vector2(defaultPos.x + 70, defaultPos.y + 55);
    }

    public void MoveHelp()
    {
        this.transform.GetChild(0).localPosition = new Vector2(defaultPos.x + 70, defaultPos.y - 55);
    }

    public void MoveBack()
    {
        this.transform.GetChild(0).localPosition = defaultPos;
    }

    public void ShrinkButton()
    {
        this.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f, 0.5f);
    }
}
