using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationeryObject
{
    public GameObject gameObject { get; }
    public Vector3 position { get; }

    public StationeryObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
        position = this.gameObject.transform.position;
    }
}
