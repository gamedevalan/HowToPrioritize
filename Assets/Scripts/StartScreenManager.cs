using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreenManager : MonoBehaviour
{
    public GameObject textBox;
    public GameObject yesButton;
    public GameObject noButton;
    public Animator animate;

    public void PlayTutorialLevel()
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "Okay, I'll teach you how make your first ever pizza!";
        StartCoroutine(CreateDialogue("Tutorial Level"));
    }


    public void PlayFirstLevel()
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "Great, then we'll get started with the first pizza of the week!";
        StartCoroutine(CreateDialogue("Level 1"));
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private IEnumerator CreateDialogue(string scene)
    {
        animate.SetTrigger("Level_Complete");
        yesButton.SetActive(false);
        noButton.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(scene);

    }
}
