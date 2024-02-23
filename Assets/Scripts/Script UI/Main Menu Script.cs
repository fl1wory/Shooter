using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
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
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject settings;

    public AudioMixer masterVolume;
    public AudioMixerGroup musicVolume;
    public AudioMixerGroup SFXVolume;

    
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;

    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;
    public Dropdown refreshRateDropdown;

    public Toggle fullscreenToggle;

    private int screenInt;

    Resolution[] resolutions;
    private bool isFullscreen = false;

    List<limits> refreshRateList = new List<limits>();
    int currentRefRate;

    const string prefName = "optionValue";
    const string resName = "resolutionValue";
    const string refRateName = "refreshRateValue";



    void Awake()
    {
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

        Debug.Log("RefreshRate" + currentRefRate);

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

        refreshRateList.Add(limits.NoLimit);
        refreshRateList.Add(limits.FPS30);
        refreshRateList.Add(limits.FPS60);
        refreshRateList.Add(limits.FPS90);
        refreshRateList.Add(limits.FPS120);
        refreshRateList.Add(limits.FPS240);
        refreshRateList.Add(limits.FPS360);
        refreshRateList.Add(limits.FPS420);

        List<string> refreshRateOptions = new List<string>();
        for (int i = 0; i < refreshRateList.Count; i++)
        {
            string option = refreshRateList[i].ToString();
            refreshRateOptions.Add(option);
            if(refreshRateList[i] == (limits)Screen.currentResolution.refreshRate)
            {
                currentRefreshRateIndex = (int)refreshRateList[i];
            }
            Debug.Log(option);
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
    public void SettingsEnter()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void SettingsExit()
    {
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void LevelSelectPlay()
    {
        mainMenu.SetActive(false);
        levelSelect.SetActive(true);
    }
    public void LevelSelectQuit()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
    public void Level2()
    {
        SceneManager.LoadScene(2);
    }

    public void Level3()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
