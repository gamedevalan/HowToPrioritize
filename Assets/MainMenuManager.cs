using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static bool finishedGame = false;
    public Image background;
    public Sprite changedBG;

    // Start is called before the first frame update
    void Start()
    {
        if (finishedGame)
        {
            background.sprite = changedBG;
        }
    }
}
