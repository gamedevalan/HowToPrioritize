using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class DraggableOnPizzaTutorial : MonoBehaviour
{
    private Topping myTopping;
    private SpriteRenderer spriteRenderer;
    private Color color;
    private Vector3 mousePositionOffset;
    private Vector3 resetPosition;
    private float zPosition;
    private bool onPizza;
    private Vector3 doughPosition;
    private Vector3 currentPosition;

    private GameObject toppingTextHolder;
    public GameObject singlePiece;
    private Sprite inContainerSprite;
    private Vector3 originalRatio;

    public bool isDraggable;

    private void Start()
    {
        myTopping = UsefulFunctions.WhatToppingAmITutorial(this.gameObject);
        zPosition = myTopping.zPosition;

        doughPosition = MainTutorial.pizzaDough.position;

        resetPosition = this.transform.localPosition;

        toppingTextHolder = GameObject.Find("What Is Topping Text").transform.GetChild(0).gameObject;
        toppingTextHolder.SetActive(false);

        originalRatio = this.transform.localScale;
        inContainerSprite = this.GetComponent<SpriteRenderer>().sprite;

        //these two lines are associated with the invisibility effect of dragging an object
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
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
            if (this.gameObject.transform.childCount != 0)
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            }
            //the two lines of code that follow make the gameobject that is being dragged slightly transparent until it is released.
            color.a = 0.6f;
            GetComponent<SpriteRenderer>().color = color;
            SoundEffects.PlayPickUp();
            // Change the sprite when picked up
            if (!myTopping.isSpread)
            {
                GetComponent<SpriteRenderer>().sprite = singlePiece.GetComponent<SpriteRenderer>().sprite;
                this.gameObject.transform.localScale = singlePiece.transform.localScale;
                this.gameObject.transform.rotation = Quaternion.identity;

            }
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
        if (DialogueManager.finishedSentence)
        {
            MouseLogic.currTopping = myTopping;
            CheckAnswer();
        }
        if (isDraggable)
        {
            if (this.gameObject.transform.childCount != 0)
            {
                this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            currentPosition = this.gameObject.transform.position;
            color.a = 1f;
            GetComponent<SpriteRenderer>().color = color;
            if (!myTopping.isSpread)
            {
                GetComponent<SpriteRenderer>().sprite = inContainerSprite;
                this.gameObject.transform.localScale = originalRatio;
                this.gameObject.transform.localRotation = Quaternion.identity;
            }
            resetPos();
        }
    }

    private void resetPos()
    {
        this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y);
    }


    public void OnMouseEnter()
    {
        toppingTextHolder.SetActive(true);
        toppingTextHolder.transform.localPosition = new Vector3(this.gameObject.transform.position.x, toppingTextHolder.transform.localPosition.y);
        toppingTextHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = myTopping.toppingTask + "";
    }

    public void OnMouseExit()
    {
        toppingTextHolder.SetActive(false);
    }

    public void SetDraggable(bool val)
    {
        isDraggable = val;
    }

    public void CheckAnswer()
    {
        MouseLogic.checkingAnswer = true;
    }
}