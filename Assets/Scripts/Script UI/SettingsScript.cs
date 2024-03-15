using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
     private enum limits
     {
        NoLimit = 0,
        FPS30 = 30,
        FPS60 = 60,
        FPS90 = 90,
        FPS120 = 120,
        FPS240 = 240,
        FPS360 = 360,
        FPS420 = 420,
     }

    /*[Header("Menu Tabs")] 
    [SerializeField]public GameObject mainMenuPanel;
    [SerializeField]public GameObject levelSelectPanel;
    [SerializeField]public GameObject settingsPanel;
    */
    [Header("Audio Mixer/Groups")]
    [SerializeField]public AudioMixer masterVolume;
    [SerializeField]public AudioMixerGroup musicVolume;
    [SerializeField]public AudioMixerGroup SFXVolume;

    [Header("Sliders")]
    [SerializeField]public Slider masterSlider;
    [SerializeField]public Slider musicSlider;
    [SerializeField]public Slider SFXSlider;

    [Header("Dropdowns")]
    [SerializeField]public Dropdown resolutionDropdown;
    [SerializeField]public Dropdown graphicsDropdown;
    [SerializeField]public Dropdown refreshRateDropdown;
    
    [Header("Toggles")]
    [SerializeField]public Toggle fullscreenToggle;

    private int screenInt;

    Resolution[] resolutions;
    private bool isFullscreen = false;

    List<limits> refreshRateList = new List<limits>();
    private int currentRefRate;

    //private GameObject previousPanel;

    const string prefName = "optionValue";
    const string resName = "resolutionValue";
    const string refRateName = "refreshRateValue";
    


    void Awake()
    {
      // previousPanel = mainMenuPanel;
        screenInt = PlayerPrefs.GetInt("toggleState");
        if(screenInt == 1)
        {
            isFullscreen = true;
            fullscreenToggle.isOn = true;
        }
        else
        {
            fullscreenToggle.isOn = false;
        }

        resolutionDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(resName,resolutionDropdown.value);
            PlayerPrefs.Save();
        }));
        refreshRateDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(refRateName, refreshRateDropdown.value);
            PlayerPrefs.Save();
        }));
        graphicsDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, graphicsDropdown.value);
            PlayerPrefs.Save();
        }));
    }
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MyMasterVolume", 1f);
        masterVolume.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MyMasterVolume"));

        musicSlider.value = PlayerPrefs.GetFloat("MyMusicVolume", 1f);
        musicVolume.audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MyMusicVolume"));

        SFXSlider.value = PlayerPrefs.GetFloat("MySFX", 1f);
        SFXVolume.audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("MySFX"));

        graphicsDropdown.value = PlayerPrefs.GetInt(prefName, 2);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        refreshRateDropdown.ClearOptions();

        List<string> options = new List<string>();
       
        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName,currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();

        int currentRefreshRateIndex = 0;
        foreach(int i in Enum.GetValues(typeof(limits)))
        {
            refreshRateList.Add((limits)i);
        }

        List<string> refreshRateOptions = new List<string>();
        for (int i = 0; i < refreshRateList.Count; i++)
        {
            string option = refreshRateList[i].ToString();
            refreshRateOptions.Add(option);
            if(refreshRateList[i] == (limits)Screen.currentResolution.refreshRateRatio.value)
            {
                currentRefreshRateIndex = (int)refreshRateList[i];
            }
        }

        refreshRateDropdown.AddOptions(refreshRateOptions);
        refreshRateDropdown.value = PlayerPrefs.GetInt(refRateName,currentRefreshRateIndex);
        refreshRateDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
         QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetRefreshRate(int refreshIndex)
    {
        Application.targetFrameRate = (int)refreshRateList[refreshIndex];
        currentRefRate = (int)refreshRateList[refreshIndex];
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;

        if(isFullscreen == false)
        {
            PlayerPrefs.SetInt("toggleState",0);
        }
        else
        {
            isFullscreen = true;
            PlayerPrefs.SetInt("toggleState",1);
        }
    }
    public void SetMasterVolume()
    {
        PlayerPrefs.SetFloat("MyMasterVolume", masterSlider.value);
        masterVolume.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MyMasterVolume"));
    }
    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("MyMusicVolume", musicSlider.value);
        musicVolume.audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MyMusicVolume"));
    }
    public void SetSFXVolume()
    {
        PlayerPrefs.SetFloat("MySFX", SFXSlider.value);
        musicVolume.audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("MySFX"));
    }
  /* public void OnButtonSettings()
    {
        ControllerPanel(settingsPanel, ref previousPanel);
    }
    public void OnButtonPlay()
    {
        ControllerPanel(levelSelectPanel, ref previousPanel);
    }
    public void OnButtonMenu()
    {
        ControllerPanel(mainMenuPanel, ref previousPanel);
    }
   */
    public void Exit()
    {
        Application.Quit();
    }
   /* private void ControllerPanel(GameObject currentPanel, ref GameObject previous)
    {
        currentPanel.SetActive(true);
        if (previous != currentPanel)
        {
            previous.SetActive(!previous.activeSelf);
            previous = currentPanel;
        }
    }
    */
    public void LevelSelector(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
