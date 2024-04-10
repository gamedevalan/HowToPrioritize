using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] music;

    public AudioSource currMusic;
    private AudioClip newTrack;

    public static BackgroundMusic instance;

    private void Start()
    {
        // Keep the same Music manager prefab.
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType<BackgroundMusic>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (ScenesManager.WhatSceneAmI().Contains("Level") || ScenesManager.WhatSceneAmI() == "Results")
        {
            newTrack = music[1];
        }
        else
        {
            newTrack = music[0];
        }

        if ((currMusic.clip == null || currMusic.clip.name != newTrack.name))
        {
            currMusic.Stop();
            currMusic.clip = newTrack;
            currMusic.Play();
        }
    }
}