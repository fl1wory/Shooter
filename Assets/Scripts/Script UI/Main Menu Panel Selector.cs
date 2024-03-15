using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanelSelector : MonoBehaviour
{
    [Header("Menu Tabs")]
    [SerializeField] public GameObject mainMenuPanel;
    [SerializeField] public GameObject levelSelectPanel;
    [SerializeField] public GameObject settingsPanel;

    private GameObject previousPanel;

    void Awake()
    {
        previousPanel = mainMenuPanel;
    }
    public void OnButtonSettings()
    {
        ControllerPanel(settingsPanel,ref previousPanel);
    }
    public void OnButtonPlay()
    {
        ControllerPanel(levelSelectPanel, ref previousPanel);
    }
    public void OnButtonMenu()
    {
        ControllerPanel(mainMenuPanel, ref previousPanel);
    }
    public void ControllerPanel(GameObject currentPanel, ref GameObject previous)
    {
        currentPanel.SetActive(true);
        if (previous != currentPanel)
        {
            previous.SetActive(!previous.activeSelf);
            previous = currentPanel;
        }
    }
}
