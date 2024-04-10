using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject confirmMenu;
    public GameObject pauseButton;

    public Slider volumeSlider;
    public Slider sfxSlider;

    public static float musicVolume = 1;
    public static float soundEffectsVolume = 1;


    private void Start()
    {
        volumeSlider.value = musicVolume;
        sfxSlider.value = soundEffectsVolume;
    }

    public void UpdateVolumeMusic()
    {
        musicVolume = volumeSlider.value;
        GameObject music = GameObject.Find("BackgroundMusic");
        if (music != null)
        {
            music.GetComponent<AudioSource>().volume = musicVolume;
        }
    }

    public void UpdateVolumeSFX()
    {
        soundEffectsVolume = sfxSlider.value;
        SoundEffects.ChangeSoundVolume();
    }

    public void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
        confirmMenu.SetActive(false);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void ShowConfirmation()
    {
        pauseMenu.SetActive(false);
        confirmMenu.SetActive(true);
    }

    public void CloseConfirmation()
    {
        pauseMenu.SetActive(true);
        confirmMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
