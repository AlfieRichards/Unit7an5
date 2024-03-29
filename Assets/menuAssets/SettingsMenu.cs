﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer masterMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    public TMPro.TMP_Dropdown QualityDropdown;

    public Toggle fullscreenToggle;

    public int currentResolutionIndex;

    public Slider master, music, effects;

    public int difficulty;

    public TextMeshProUGUI diffText;

    public GameObject pauseFirstButton, settingsFirstButton, helpFirstButton, audioFirstButton, videoFirstButton, difficultyFirstButton;

    Resolution[] resolutions;

    void Start ()
    {

        //clear selected objecy
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);





        //Loads all player prefs except resolution
        LoadPrefs();

        //sets diff
        ReadDiff();

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionIndex");
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
    }


    public void SetEffectsVolume (float volume)
    {
        masterMixer.SetFloat("SfxVolume", volume);
        PlayerPrefs.SetFloat("SfxVolume", volume);
        Debug.Log(volume);
    }

    public void SetMusicVolume (float volume)
    {
        masterMixer.SetFloat("BgmVolume", volume);
        PlayerPrefs.SetFloat("BgmVolume", volume);
        Debug.Log(volume);
    }

    public void SetMasterVolume (float volume)
    {
        masterMixer.SetFloat("MasterVolume", volume);
        PlayerPrefs.SetFloat("MasterVolume", volume);
        Debug.Log(volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityLevel", qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if(isFullscreen)
        {
            PlayerPrefs.SetInt("FullscreenBool", 1);
            fullscreenToggle.isOn = true;
        }
        else
        {
            PlayerPrefs.SetInt("FullscreenBool", 0);
            fullscreenToggle.isOn = false;
        }
    }

    void CheckFullscreen(int num)
    {
        if(num == 1)
        {
            SetFullscreen(true);
            PlayerPrefs.SetInt("FullscreenBool", num);
            fullscreenToggle.isOn = true;
        }
        else
        {
            SetFullscreen(false);
            PlayerPrefs.SetInt("FullscreenBool", num);
            fullscreenToggle.isOn = false;
        }
    }


    public void SetDifficulty (int Tdifficulty)
    {
        PlayerPrefs.SetInt("Difficulty", Tdifficulty);
        ReadDiff();
        //Debug.Log(Tdifficulty);
    }

    void ReadDiff()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
        if(difficulty == 0){
            diffText.text = "Current: easy";
        }
        if(difficulty == 1){
            diffText.text = "Current: medium";
        }
        if(difficulty == 2){
            diffText.text = "Current: hard";
        }
        else{
            Debug.Log("panic");
        }

    }

    void LoadPrefs()
    {
        QualityDropdown.value = PlayerPrefs.GetInt("QualityLevel");
        master.value = PlayerPrefs.GetFloat("MasterVolume");
        music.value = PlayerPrefs.GetFloat("BgmVolume");
        effects.value = PlayerPrefs.GetFloat("SfxVolume");
        CheckFullscreen(PlayerPrefs.GetInt("FullscreenBool"));
        difficulty = PlayerPrefs.GetInt("Difficulty");
    }

    public void SelectPlay()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void SelectOptions()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }

    public void SelectVideo()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(videoFirstButton);
    }

    public void SelectDifficulty()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(difficultyFirstButton);
    }

    public void SelectAudio()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(audioFirstButton);
    }

    public void SelectHelp()
    {
        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set new selection
        EventSystem.current.SetSelectedGameObject(helpFirstButton);
    }

    public void PlaySelect()
    {
        FindObjectOfType<AudioManager>().Play("select");
    }

}
