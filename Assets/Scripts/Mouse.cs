using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Prompt {
    public string promptString;
    public Topping correctChoice;
    public int goal;
    public string specialResponse;
}


public class Mouse
{
    public List<Prompt> prompts = new List<Prompt>();
    public GameObject mouseGO { get;}
    public string Welcome { get; set; }
    public string Congrats { get; set; }
    public string CorrectAnswer { get; set; }


    public Mouse(GameObject mouseGO) {
        this.mouseGO = mouseGO;
    }

    public void CreatePrompt(string promptString, Topping correctChoice, int goal, string specialResponse) {
        Prompt p = new Prompt();
        p.promptString = promptString;
        p.correctChoice = correctChoice;
        p.goal = goal;
        p.specialResponse = specialResponse;
        prompts.Add(p);
    }

    


}
