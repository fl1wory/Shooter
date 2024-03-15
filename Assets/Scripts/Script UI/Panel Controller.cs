using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public void ControllerPanel(GameObject currentPanel,GameObject previous)
    {
        currentPanel.SetActive(true);
        if (previous != currentPanel)
        {
            previous.SetActive(!previous.activeSelf);
            previous = currentPanel;
        }
    }
}
