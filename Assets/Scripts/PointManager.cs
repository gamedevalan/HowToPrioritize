using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PointManager : MonoBehaviour
{
    public GameObject pointText;

    private static PointManager instance;
    int points;

    private void Start()
    {
        instance = this;
        points = 0;
    }

    private void Update()
    {
        instance.pointText.GetComponent<TextMeshProUGUI>().text = "Points: \n " + points;
    }

    public static void UpdatePoints(int amount)
    {
        instance.points = amount;
    }
}
