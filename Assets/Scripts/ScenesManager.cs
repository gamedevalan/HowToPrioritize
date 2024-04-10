using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("StartScreen");
        ResultsManager.ResetNumberWrong();
    }

    public void StartLevelOne()
    {
        SceneManager.LoadScene("Level 1");
        ResultsManager.ResetNumberWrong();
    }

    public void SwitchLevels()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SwitchToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public static string WhatSceneAmI()
    {
        return SceneManager.GetActiveScene().name;
    }


}
