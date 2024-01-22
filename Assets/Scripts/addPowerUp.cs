using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addPowerUp : MonoBehaviour
{
    void OnEnable()
    {
        pickPowerUp.OnPowerUps += PowerUpCollected;
    }

    void OnDisable()
    {
        pickPowerUp.OnPowerUps -= PowerUpCollected;
    }

    void PowerUpCollected(string name)
    {
        Debug.Log(name);
    }
}
