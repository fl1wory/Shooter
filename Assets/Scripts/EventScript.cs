using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{
    [SerializeField] UnityEvent OnShoot;

    public void onShoot()
    {
        OnShoot.Invoke();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onShoot();
        }
    }
}
