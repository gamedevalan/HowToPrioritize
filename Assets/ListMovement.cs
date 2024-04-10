using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMovement : MonoBehaviour
{
    private Vector2 originalPos;

    private void Start()
    {
        originalPos = this.transform.localPosition;    
    }

    public void MoveUp()
    {
        this.transform.localPosition = new Vector2(originalPos.x, originalPos.y + 40);
    }

    public void MoveDown()
    {
        this.transform.localPosition = originalPos;
    }
}
