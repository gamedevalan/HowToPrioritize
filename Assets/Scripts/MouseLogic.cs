using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLogic : MonoBehaviour
{
    public static bool dragging = false;
    public static Topping currTopping;
    public static bool checkingAnswer = false;

    public GameObject addedPointText;
    public GameObject pressSpaceText;

    public Animator animate;

    // Only needed for tutorial
    public GameObject arrow;

    private readonly string[] incorrectPrompts = { "Uh-oh! That’s not the correct answer.", "Oops... Let’s think about it more.",
        "A little bit away from the correct answer...", "Oh no, that was incorrect. You’ll soon get the correct answer."};

    void Start()
    {
        addedPointText.SetActive(false);
        pressSpaceText.SetActive(false);
        if (ScenesManager.WhatSceneAmI() == "Bonus Level")
        {
            // Do nothing
        }
        else if (ScenesManager.WhatSceneAmI() != "Tutorial Level") {
            StartCoroutine(Dialogue());
        }
        else
        {
            StartCoroutine(TutorialDialogue());
        }
    }

    IEnumerator Dialogue()
    {
        UsefulFunctions.SetIfToppingDraggable(false);
        SoundEffects.PlayMouse();
        if (ScenesManager.WhatSceneAmI() == "Level 1")
        {
            animate.SetTrigger("Talking");
            DialogueManager.ShowSentence(Main.mouse.Welcome);
            yield return WaitForKeyPress();
        }

        bool done = false;
        for (int i = 0; i < Main.mouse.prompts.Count; i++)
        {
            done = false;
            while (!done)
            {
                UsefulFunctions.SetIfToppingDraggable(false);
                animate.SetTrigger("Talking");
                DialogueManager.ShowSentence(Main.mouse.prompts[i].promptString);
                checkingAnswer = false;
                yield return WaitForAnswer();

                //if (Main.mouse.prompts[i].correctChoice.counter == Main.mouse.prompts[i].goal) {//if correct, again, needs implementation
                if (Main.mouse.prompts[i].correctChoice == currTopping)
                {
                    animate.SetTrigger("Correct");
                    SoundEffects.PlayRightAnswer();
                    DialogueManager.ShowSentence(Main.mouse.CorrectAnswer + Main.mouse.prompts[i].goal + " " + Main.mouse.prompts[i].correctChoice.toppingName);
                    UsefulFunctions.SetToppingDraggable(Main.mouse.prompts[i].correctChoice.toppingName);
                    yield return WaitForDrag(i);
                    UpdatePointAnimation.UpdateText(100);
                    addedPointText.SetActive(true);
                    done = true;
                    GameObject temp = GameObject.Find("Toppings On Pizza Holder").transform.gameObject;
                    foreach(Transform child in temp.transform)
                    {
                        child.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                    }
                    if (Main.mouse.prompts[i].specialResponse != "")
                    {
                        animate.SetTrigger("Talking");
                        UsefulFunctions.SetIfToppingDraggable(false);
                        DialogueManager.ShowSentence(Main.mouse.prompts[i].specialResponse);
                        yield return WaitForKeyPress();
                    }
                }
                else
                {//if incorrect
                    animate.SetTrigger("Incorrect");
                    SoundEffects.PlayWrongAnswer();
                    ResultsManager.AddWrong();
                    int rand = Random.Range(0,4);
                    DialogueManager.ShowSentence(incorrectPrompts[rand] + " Please press space and try again.");
                    yield return WaitForKeyPress();
                }

            }
        }

        //TODO: check if passed level or not.
        //if passed -> print Congrats message.
        //else -> print failure.
        UsefulFunctions.SetIfToppingDraggable(false);
        DialogueManager.ShowSentence(Main.mouse.Congrats);
        animate.SetTrigger("Level_Complete");
        yield return WaitForKeyPress();
        UpdatePointAnimation.UpdateText(500);
        addedPointText.SetActive(true);
        Main.NextButtonShow();
        animate.SetTrigger("New_Level");
    }

    IEnumerator TutorialDialogue()
    {
        arrow.gameObject.SetActive(false);
        DialogueManager.ShowSentence("Before customers come in, let’s try a small pizza.");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("Here is a new order. Click to see detailed information about the pizza. You can also look back whenever you need to.");
        arrow.gameObject.SetActive(true);
        yield return WaitForKeyPress();
        arrow.gameObject.SetActive(false);
        DialogueManager.ShowSentence("Each ingredient represents a daily task. You can move your mouse onto the ingredients to see what they are. Click and drag the ingredients onto the pizza dough to earn points!");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("Each pizza has five questions, each with five choices. You should choose the only correct ingredient to earn points.");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("However, for this small pizza, there are only two.");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("It’s a school day, I’m going to ask you to prioritize some of these tasks.");
        yield return WaitForKeyPress();
        bool done = false;
        for (int i = 0; i < MainTutorial.mouse.prompts.Count; i++)
        {
            done = false;
            while (!done)
            {
                UsefulFunctions.SetIfToppingDraggableTutorial(false);
                animate.SetTrigger("Talking");
                DialogueManager.ShowSentence(MainTutorial.mouse.prompts[i].promptString);
                checkingAnswer = false;
                yield return WaitForAnswer();

                //if (Main.mouse.prompts[i].correctChoice.counter == Main.mouse.prompts[i].goal) {//if correct, again, needs implementation
                if (MainTutorial.mouse.prompts[i].correctChoice == currTopping)
                {
                    animate.SetTrigger("Correct");
                    SoundEffects.PlayRightAnswer();
                    DialogueManager.ShowSentence(MainTutorial.mouse.CorrectAnswer + MainTutorial.mouse.prompts[i].goal + " " + MainTutorial.mouse.prompts[i].correctChoice.toppingName);
                    UsefulFunctions.SetToppingDraggableTutorial(MainTutorial.mouse.prompts[i].correctChoice.toppingName);
                    yield return WaitForDragTutorial(i);
                    UpdatePointAnimation.UpdateText(100);
                    addedPointText.SetActive(true);
                    done = true;
                    if (MainTutorial.mouse.prompts[i].specialResponse != "")
                    {
                        animate.SetTrigger("Talking");
                        UsefulFunctions.SetIfToppingDraggableTutorial(false);
                        DialogueManager.ShowSentence(MainTutorial.mouse.prompts[i].specialResponse);
                        yield return WaitForKeyPress();
                    }
                }
                else
                {//if incorrect
                    animate.SetTrigger("Incorrect");
                    SoundEffects.PlayWrongAnswer();
                    int rand = Random.Range(0, 4);
                    DialogueManager.ShowSentence(incorrectPrompts[rand] + " Please press space and try again.");
                    yield return WaitForKeyPress();
                }

            }
        }
        UsefulFunctions.SetIfToppingDraggableTutorial(false);
        DialogueManager.ShowSentence("You completed this pizza, congratulations!");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("You can see you earned points. " +
            "Complete more orders to level up the pizzeria, you will unlock upgraded backgrounds and new clothes for me!");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("And maybe there will be a hidden level... So please try your best!");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("If you still feel confused, you can click on the Tutorial in the main menu to retry this small pizza. " +
            "Or you can click on the Help in the main menu to see what each object does.");
        yield return WaitForKeyPress();
        DialogueManager.ShowSentence("I believe you are ready now. Let’s work together for this pizzeria!");
        yield return WaitForKeyPress();

        animate.SetTrigger("Level_Complete");
        UpdatePointAnimation.UpdateText(500);
        addedPointText.SetActive(true);
        MainTutorial.NextButtonShow();
        MainTutorial.SkipButtonHide();
        animate.SetTrigger("New_Level");
    }

    IEnumerator WaitForAnswer()
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            // add if the current sprite you press down on is an ingredient.
            if (DialogueManager.finishedSentence && checkingAnswer)
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }

    IEnumerator WaitForDrag(int i)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            // add if the current sprite you press down on is an ingredient.
            if (DialogueManager.finishedSentence && Main.mouse.prompts[i].correctChoice.counter == Main.mouse.prompts[i].goal)
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }

    IEnumerator WaitForDragTutorial(int i)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            // add if the current sprite you press down on is an ingredient.
            if (DialogueManager.finishedSentence && MainTutorial.mouse.prompts[i].correctChoice.counter == MainTutorial.mouse.prompts[i].goal)
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }

    IEnumerator WaitForKeyPress()
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (DialogueManager.finishedSentence)
            {
                pressSpaceText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    done = true; // breaks the loop
                }
            }
            
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
        currTopping = null;
        pressSpaceText.SetActive(false);
        SoundEffects.PlayMouse();
    }

}
