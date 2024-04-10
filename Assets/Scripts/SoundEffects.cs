using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource manager;
    public AudioClip pickUp;
    public AudioClip putDown;
    public AudioClip wrong;
    public AudioClip right;
    public AudioClip mouseSqueak;
    public static SoundEffects instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        manager.volume = PauseManager.soundEffectsVolume;
    }

    public static void ChangeSoundVolume()
    {
        instance.manager.volume = PauseManager.soundEffectsVolume;
    }

    public static void PlayPickUp()
    {
        instance.manager.clip = instance.pickUp;
        instance.manager.Play();
    }

    public static void PlayPutDown()
    {
        instance.manager.clip = instance.putDown;
        instance.manager.Play();
    }

    public static void PlayWrongAnswer()
    {
        instance.manager.clip = instance.wrong;
        instance.manager.Play();
    }

    public static void PlayRightAnswer()
    {
        instance.manager.clip = instance.right;
        instance.manager.Play();
    }

    public static void PlayMouse()
    {
        instance.manager.clip = instance.mouseSqueak;
        instance.manager.Play();
    }
}
