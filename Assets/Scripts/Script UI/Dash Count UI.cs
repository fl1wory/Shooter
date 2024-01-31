using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCountUI : MonoBehaviour
{
    [SerializeField] Text dashText;

    public void SetDashCount(int dashCount)
    {
        dashText.text = dashCount.ToString();
    }
}
