using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelManager : MonoBehaviour
{
    public GameObject[] toppingsTable;
    public GameObject[] toppingsPizza;


    public GameObject pizzaDoughGO;
    public GameObject trashCanGO;
    public GameObject mouseGO;
    public static StationeryObject pizzaDough;
    public static StationeryObject trashCan;

    public static Mouse mouse;
    public GameObject hintScreen;
    public GameObject nextButton;
    public static BonusLevelManager instance;

    private List<GameObject> showToppings;
    int maxNum;
    int count;

    private void Start()
    {
        instance = this;

        pizzaDough = new StationeryObject(pizzaDoughGO);
        trashCan = new StationeryObject(trashCanGO);

        if (ResultsManager.numWrong < 5)
        {
            maxNum = 3;
        }
        else
        {
            maxNum = 2;
        }
    }

    public void SwitchIngredients()
    {
        toppingsTable[count % maxNum].SetActive(false);
        count++;
        toppingsTable[count % maxNum].SetActive(true);
    }
}
