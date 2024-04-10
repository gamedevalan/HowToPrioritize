using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    public GameObject resultText;
    public GameObject menuButton;
    public GameObject nextButton;

    public static int numWrong;

    private void Start()
    {
        MainMenuManager.finishedGame = true;
        if (numWrong < 5)
        {
            nextButton.SetActive(true);
            menuButton.SetActive(false);
            if (numWrong == 1)
            {
                resultText.GetComponent<TextMeshProUGUI>().text = "Excellent! You've completed all pizzas with only " + numWrong + " wrong try. " +
                "You are a master at prioritizing! Now it's time to make your own pizza that fits your own taste.";
            }
            else
            {
                resultText.GetComponent<TextMeshProUGUI>().text = "Excellent! You've completed all pizzas with only " + numWrong + " wrong tries. " +
                "You are a master at prioritizing! Now it's time to make your own pizza that fits your own taste.";
            }
        }
        else if (numWrong <= 10)
        {
            nextButton.SetActive(true);
            menuButton.SetActive(false);
            resultText.GetComponent<TextMeshProUGUI>().text = "Great! You've completed all pizzas with only " + numWrong + " wrong tries. " +
                            "You are pretty good at prioritizing... " +
                            "keep improving on it and you can become a master at prioritizing! Now it's time to make your own pizza that fits your own taste.";
        }
        else
        {
            nextButton.SetActive(false);
            menuButton.SetActive(true);
            resultText.GetComponent<TextMeshProUGUI>().text = "Congratulations on completing all the pizzas! However, you got " + numWrong + " wrong tries. A little too many... " +
                "Please try the game again to learn to prioritize your daily tasks.";
        }
    }

    public static void AddWrong()
    {
        numWrong++;
    }

    public static void ResetNumberWrong()
    {
        numWrong = 0;
    }
}
