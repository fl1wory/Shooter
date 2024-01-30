using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField]Text ammoText;

    public void AmmoSet(int ammoIndex)
    {
        ammoText.text = ammoIndex.ToString();
    }
}
