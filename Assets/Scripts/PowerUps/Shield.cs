using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    public void SetShield()
    {
        shield.SetActive(true);
    }
}
