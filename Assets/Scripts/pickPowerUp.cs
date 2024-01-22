using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickPowerUp : MonoBehaviour
{
    public delegate void powerUps(string name);
    public static event powerUps OnPowerUps;


    public void CollectionPowerUps(string name)
    {
        OnPowerUps?.Invoke(name);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CollectionPowerUps("Shield");
        }
    }
}
