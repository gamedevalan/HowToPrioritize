using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePointAnimation : MonoBehaviour
{
    public static int points;
    public static UpdatePointAnimation instance;

    private void Start()
    {
        instance = this;
        points = 0;
    }

    public static void UpdateText(int pointAmount)
    {
        instance.gameObject.GetComponent<TextMeshProUGUI>().text = "+" + pointAmount;
        points += pointAmount;
    }

    public void UpdatePointsQuestion()
    {
        PointManager.UpdatePoints(points);
        this.gameObject.SetActive(false);
    }
}
