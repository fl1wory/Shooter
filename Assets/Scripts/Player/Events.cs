using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsScript : MonoBehaviour
{
    public GunsInventory inventory;
    [SerializeField] UnityEvent OnShootCluster;
    [SerializeField] UnityEvent OnShootHoming;

    public void onShootCluster()
    {
        OnShootCluster.Invoke();
    }

    public void onShootHoming()
    { 
        OnShootHoming.Invoke();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0) && inventory.index == 0)
        {
            onShootCluster();
        }

        if (Input.GetMouseButtonDown(0) && inventory.index == 1)
        {
            onShootHoming();
        }
    }
}
