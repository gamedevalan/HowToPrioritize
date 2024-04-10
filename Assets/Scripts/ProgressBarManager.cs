using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBarManager : MonoBehaviour
{
    public Image progressBar;

    // Start is called before the first frame update
    void Start()
    {
        progressBar.fillAmount = ScenesManager.WhatSceneAmI() != "Tutorial Level" ? (SceneManager.GetActiveScene().buildIndex - 1) / 7f : 0f;
    }
}
