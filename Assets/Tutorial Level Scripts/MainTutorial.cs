using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTutorial : MonoBehaviour
{
    public GameObject topping_1_table_go, topping_1_pizza_go;
    public GameObject topping_2_table_go, topping_2_pizza_go;

    public GameObject pizzaDoughGO;
    public GameObject trashCanGO;
    public GameObject mouseGO;

    public static List<Topping> toppings = new List<Topping>();
    public static List<GameObject> toppingTableObjects = new List<GameObject>();

    public Topping topping_1;
    public Topping topping_2;

    public static StationeryObject pizzaDough;
    public static StationeryObject trashCan;

    public static Mouse mouse;
    public GameObject hintScreen;
    public GameObject nextButton;
    public GameObject skipButton;
    public static MainTutorial instance;

    private ScenesManager scenesManager;

    void Start()
    {
        instance = this;
        Setup();
        skipButton.SetActive(true);
        nextButton.SetActive(false);

        pizzaDough = new StationeryObject(pizzaDoughGO);
        trashCan = new StationeryObject(trashCanGO);

        toppings.Add(topping_1);
        toppings.Add(topping_2);

        toppingTableObjects.Add(topping_1_table_go);
        toppingTableObjects.Add(topping_2_table_go);

    }

    private void Setup()
    {
        topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Tomato Sauce", "Hygiene", 0f, true);
        topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Pepperoni", "Lunch", -0.1f, false);

        mouse = new Mouse(mouseGO);
        mouse.CreatePrompt("Now it’s 7:30 am, and you wake up! Which event would you do first after getting up? Please choose the topping.", topping_1, 1, "Correct! You need to brush your teeth and wash your face right after getting up.");
        mouse.CreatePrompt("It’s noon. You have completed all morning classes, and what should you do now?", topping_2, 2, "Awesome! It’s lunchtime.");
        mouse.Welcome = "Welcome to your first day on the job. I hope you are well prepared. Let's get started!";
        mouse.Congrats = "Congrats! You successfully completed the pizza!";
        mouse.CorrectAnswer = "Correct! Now please drag ";

        toppings.Clear();
        toppingTableObjects.Clear();
    }

    public static Mouse GetMouseObject()
    {
        return mouse;
    }

    public void HintButtonShow()
    {
        hintScreen.SetActive(true);
    }

    public void HintButtonHide()
    {
        hintScreen.SetActive(false);
    }

    public static void NextButtonShow()
    {
        instance.nextButton.SetActive(true);
    }

    public static void SkipButtonHide()
    {
        instance.skipButton.SetActive(false);
    }
}
