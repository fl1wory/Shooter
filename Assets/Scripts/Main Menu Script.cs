using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject settings;

    public AudioMixer masterVolume;
    public Slider volSlider;

    public Dropdown resolutionDropdown;
    public Dropdown graphicsDropdown;

    public Toggle fullscreenToggle;

    private int screenInt;

    Resolution[] resolutions;
    private bool isFullscreen = false;


    const string prefName = "optionValue";
    const string resName = "resolutionValue";



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
        graphicsDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
        {
            PlayerPrefs.SetInt(prefName, graphicsDropdown.value);
            PlayerPrefs.Save();
        }));
    }
    void Start()
    {
        volSlider.value = PlayerPrefs.GetFloat("MyVolume", 1f);
        masterVolume.SetFloat("volume", PlayerPrefs.GetFloat("MyVolume"));

        graphicsDropdown.value = PlayerPrefs.GetInt(prefName, 2);

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height &&
                resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = PlayerPrefs.GetInt(resName,currentResolutionIndex);
        resolutionDropdown.RefreshShownValue();
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
    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("MyVolume",volume);
        masterVolume.SetFloat("volume",PlayerPrefs.GetFloat("MyVolume"));

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
    public void Exit()
    {
        Application.Quit();
    }
}
