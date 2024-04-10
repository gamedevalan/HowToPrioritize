using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableOnTrash : MonoBehaviour
{

    private Topping myTopping;
    private Vector3 mousePositionOffset = new Vector3();
    private Vector3 resetPosition;
    private SpriteRenderer spriteRenderer;
    private Color color;
    private Vector3 trashCanPosition;
    private bool onTrash;

    public bool isDraggable;

    private void Start()
    {
        myTopping = UsefulFunctions.WhatToppingAmI(this.gameObject);
        trashCanPosition = Main.trashCan.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = GetComponent<SpriteRenderer>().color;
    }

    private Vector3 GetMouseWorldPosition()//get mouse position and return world point.
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        if (isDraggable)
        {
            resetPosition = this.transform.localPosition;
            mousePositionOffset = this.gameObject.transform.position - GetMouseWorldPosition();

            //the two lines of code that follow make the gameobject that is being dragged slightly transparent until it is released.
            color.a = 0.6f;
            GetComponent<SpriteRenderer>().color = color;
        }
    }

    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private void OnMouseUp()
    {
        if (isDraggable)
        {
            color.a = 1f;
            GetComponent<SpriteRenderer>().color = color;

            if (onTrash)
            {
                DeleteTopping.DeleteToppingOnPizza(this.gameObject, myTopping);
            }
            else
            {
                this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);

            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == Main.trashCan.gameObject.name)
        {
            onTrash = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == Main.trashCan.gameObject.name)
        {
            onTrash = false;
        }
    }

    public void SetDraggable(bool val)
    {
        isDraggable = val;
    }

}
