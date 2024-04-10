using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject textDisplay;
    public int index;
    public float typingSpeed;
    public static bool finishedSentence;

    public Mouse currMouse;

    public static DialogueManager instance;

    private void Start()
    {
        currMouse = Main.GetMouseObject();
        textDisplay.GetComponent<TextMeshProUGUI>().text = "";
        instance = this;
    }

    public static void ShowSentence(string sentence)
    {
        instance.textDisplay.GetComponent<TextMeshProUGUI>().text = "";
        instance.StartCoroutine(instance.Type(sentence));
    }

    IEnumerator Type(string sentence)
    {
        finishedSentence = false;
        foreach (char letter in sentence)
        {
            // Type writer text display.
            textDisplay.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        finishedSentence = true;
    }
}
