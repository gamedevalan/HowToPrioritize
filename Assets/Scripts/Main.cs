using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject topping_1_table_go, topping_1_pizza_go;
    public GameObject topping_2_table_go, topping_2_pizza_go;
    public GameObject topping_3_table_go, topping_3_pizza_go;
    public GameObject topping_4_table_go, topping_4_pizza_go;
    public GameObject topping_5_table_go, topping_5_pizza_go;
    public GameObject pizzaDoughGO;
    public GameObject trashCanGO;
    public GameObject mouseGO;

    public static List<Topping> toppings = new List<Topping>();
    public static List<GameObject> toppingTableObjects = new List<GameObject>();


    public Topping topping_1;
    public Topping topping_2;
    public Topping topping_3;
    public Topping topping_4;
    public Topping topping_5;

    public static StationeryObject pizzaDough;
    public static StationeryObject trashCan;

    public static Mouse mouse;
    public GameObject hintScreen;
    public GameObject nextButton;
    public static Main instance;

    public string sceneString { get; set; }
    private ScenesManager scenesManager;

    private enum State {//states are direcetly associated to the scenes in the game. 
        MainMenu,
        Level_1,
        Level_2,
        Level_3,
        Level_4,
        Level_5,
        Level_6,
        Level_7
    }

    private State state;

    void Start()
    {
        instance = this;
        SwitchState(ScenesManager.WhatSceneAmI());
        UpdateStateData();
        nextButton.SetActive(false);

        pizzaDough = new StationeryObject(pizzaDoughGO);
        trashCan = new StationeryObject(trashCanGO);

        toppings.Add(topping_1);
        toppings.Add(topping_2);
        toppings.Add(topping_3);
        toppings.Add(topping_4);
        toppings.Add(topping_5);

        toppingTableObjects.Add(topping_1_table_go);
        toppingTableObjects.Add(topping_2_table_go);
        toppingTableObjects.Add(topping_3_table_go);
        toppingTableObjects.Add(topping_4_table_go);
        toppingTableObjects.Add(topping_5_table_go);

    }

    private void UpdateStateData()
    {
        switch (state)
        {
            case State.MainMenu:
                break;
            case State.Level_1:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Tomato Sauce", "Hygiene", 0f, true);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Cheese", "Meal", -0.1f, true);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Pepperoni", "Exercise", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Ham", "School", -0.3f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Mushrooms", "Homework", -0.4f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("Now it’s 7:30 am, and you wake up! Which event would you do first after getting up? Please choose the topping.", topping_1, 1, "");
                mouse.CreatePrompt("Then let’s think about the next thing to do in the morning. What’s that?", topping_2, 1, "");
                mouse.CreatePrompt("It’s a school day. Hmm... what should you do next?", topping_4, 4, "");
                mouse.CreatePrompt("Now it’s not bad to have a break! What should you do during the break?", topping_3, 3, "");
                mouse.CreatePrompt("School is done! But there's something important tomorrow... What should you do before sleeping?", topping_5, 3, "Great! Remember you have a math quiz tomorrow, so it’s good to prepare for it as a priority.");
                mouse.Welcome = "Welcome to your first day on the job. I hope you are well prepared. Let's get started!";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
            case State.Level_2:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Tomato Sauce", "School", 0f, true);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Cheese", "Play with friends", -0.1f, true);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Onions", "Go to bed", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Mushrooms", "Prepare dinner", -0.4f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Pepperoni", "Tidy up room", -0.3f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("You get up at 7:30 am, as usual. It’s a school day, so what do you need to do at 8:30 am? Please choose the topping.", topping_1, 1, "");
                mouse.CreatePrompt("It's time for recess! What would you like to do?", topping_2, 1, "");
                mouse.CreatePrompt("You get home at 3:30 pm. Now it’s time to... ?", topping_5, 4, "");
                mouse.CreatePrompt("It’s time close to dinner. Remember your dad told you something...", topping_4, 2, "");
                mouse.CreatePrompt("Another wonderful day ends! Now it’s 9:30 pm. The last thing you need to do is...", topping_3, 4, "");
                //mouse.Welcome = "Welcome!, I am your assistant. To learn about today's pizza, click the To-Do List. Press space when ready to play.";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
            case State.Level_3:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Tomato Sauce", "Breakfast", 0f, true);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Cheese", "Prepare for picnic", -0.1f, true);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Bacon", "Wash Car", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Ham", "Study", -0.4f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Tomatoes", "Go to Bed", -0.3f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("Wow it’s a weekend day! It’s 9:00 am on Saturday. What do you need to do?", topping_1, 1, "Correct. Breakfast is still needed for weekends! It’s good for your health.");
                mouse.CreatePrompt("It’s 10:00 am. Your family is preparing for something special, what should you do?", topping_2, 1, "Awesome! You will have a picnic at noon!");
                mouse.CreatePrompt("After having the picnic, you spend time with your family at home. What can you do now?", topping_3, 4, "");
                mouse.CreatePrompt("Now it’s 3:00 pm, still early for dinner. Think about what else you could do.", topping_4, 3, "Great! Remember you have your midterms next week.");
                mouse.CreatePrompt("Another wonderful day ends! Now it’s 9:30 pm. The last thing you need to do is...?", topping_5, 3, "");
                //mouse.Welcome = "Welcome!, I am your assistant. To learn about today's pizza, click the To-Do List. Press space when ready to play.";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
            case State.Level_4:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Ham", "Clean the house", 0f, false);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Pepperoni", "Make the bed", -0.1f, false);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Mushrooms", "Lunch", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Onions", "Prepare dinner", -0.4f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Olives", "Play games", -0.3f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("Today you’ll welcome your cousin’s family. Many tasks are waiting... What should you do first?", topping_1, 3, "");
                mouse.CreatePrompt("Then what’s next?", topping_2, 3, "");
                mouse.CreatePrompt("Now it’s 12:00 pm. What do you need to do?", topping_3, 2, "");
                mouse.CreatePrompt("Your cousin came at 3:00 pm. Now it’s 4:00 pm. It’s time to do what?", topping_4, 2, "");
                mouse.CreatePrompt("After dinner, you spend time with your cousin. Hmm... What is the best thing to do with them?", topping_5, 3, "");
                //mouse.Welcome = "Welcome!, I am your assistant. To learn about today's pizza, click the To-Do List. Press space when ready to play.";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
            case State.Level_5:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Tomato Sauce", "Get up", 0f, true);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Cheese", "School", -0.1f, true);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Tomatoes", "Do laundry", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Mushrooms", "Study", -0.4f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Onions", "Walk the dog", -0.3f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("School day? School day! It’s 7:30 am. What do you need to do?", topping_1, 1, "");
                mouse.CreatePrompt("Now it’s 8:30 am! You need to?", topping_2, 1, "");
                mouse.CreatePrompt("You come home after school. Your dog is now sleeping. What should you do now?", topping_3, 3, "Great! You promised your mom to help with laundry. ");
                mouse.CreatePrompt("Then it’s time for yourself. What should you do?", topping_4, 3, "");
                mouse.CreatePrompt("After dinner, you remember you have another thing to do. It’s time for...?", topping_5, 3, "");
                //mouse.Welcome = "Welcome!, I am your assistant. To learn about today's pizza, click the To-Do List. Press space when ready to play.";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
            case State.Level_6:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Bacon", "Go to library", 0f, false);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Chicken", "Lunch", -0.1f, false);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Olives", "Go to dentist", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Green Peppers", "Piano", -0.4f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Onions", "Go to bed", -0.3f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("Good morning! It's a weekend day! Now it’s 10:00 am. What should you do?", topping_1, 4, "Great! Remember your family has this plan.");
                mouse.CreatePrompt("It’s noon now, and everyone feels hungry. What should you do?", topping_2, 4, "");
                mouse.CreatePrompt("What should you do next?", topping_3, 2, "Perfect! You have an appointment with your dentist.");
                mouse.CreatePrompt("Now it’s after dinner. And what should you do before sleep?", topping_4, 2, "Bingo! You’ll have a piano class tomorrow. Be prepared for it!");
                mouse.CreatePrompt("Another wonderful day ends! Now it’s 9:30 pm. The last thing you need to do is...?", topping_5, 3, "");
                //mouse.Welcome = "Welcome!, I am your assistant. To learn about today's pizza, click the To-Do List. Press space when ready to play.";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
            case State.Level_7:
                topping_1 = new Topping(topping_1_table_go, topping_1_pizza_go, "Fish", "Get up", 0f, false);
                topping_2 = new Topping(topping_2_table_go, topping_2_pizza_go, "Shrimp", "Piano class", -0.1f, false);
                topping_3 = new Topping(topping_3_table_go, topping_3_pizza_go, "Lemons", "Drop package", -0.2f, false);
                topping_4 = new Topping(topping_4_table_go, topping_4_pizza_go, "Mushrooms", "Homework", -0.4f, false);
                topping_5 = new Topping(topping_5_table_go, topping_5_pizza_go, "Onions", "Go to bed", -0.3f, false);

                mouse = new Mouse(mouseGO);
                mouse.CreatePrompt("It’s 8:00 am on Sunday, but you’re still in bed... What should you do first?", topping_1, 3, "");
                mouse.CreatePrompt("Now it’s 9:00 am. What should you do?", topping_2, 3, "");
                mouse.CreatePrompt("Now you’re on your way home... What can you do on the way?", topping_3, 2, "");
                mouse.CreatePrompt("Now it’s after dinner. What should you do before sleeping?", topping_4, 2, "Bingo! It’s Monday tomorrow, so remember to finish your homework!");
                mouse.CreatePrompt("Another wonderful day ends! Now it’s 9:30 pm. The last thing you need to do is...?", topping_5, 3, "");
                //mouse.Welcome = "Welcome!, I am your assistant. To learn about today's pizza, click the To-Do List. Press space when ready to play.";
                mouse.Congrats = "Congrats! You successfully completed the pizza!";
                mouse.CorrectAnswer = "Correct! Now please drag ";
                break;
        }
        toppings.Clear();
        toppingTableObjects.Clear();
    }


    public void SwitchState(string newState)
    {
        if (newState.Equals("Main Menu"))
        {
            state = State.MainMenu;
        }
        else if (newState.Equals("Level 1"))
        {
            state = State.Level_1;
        }
        else if (newState.Equals("Level 2"))
        {
            state = State.Level_2;
        }
        else if (newState.Equals("Level 3"))
        {
            state = State.Level_3;
        }
        else if (newState.Equals("Level 4"))
        {
            state = State.Level_4;
        }
        else if (newState.Equals("Level 5"))
        {
            state = State.Level_5;
        }
        else if (newState.Equals("Level 6"))
        {
            state = State.Level_6;
        }
        else if (newState.Equals("Level 7"))
        {
            state = State.Level_7;
        }
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
}
