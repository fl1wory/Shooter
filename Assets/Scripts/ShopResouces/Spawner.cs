using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnLocations;
    [SerializeField] protected GameObject spawnObject;


    void Start()
    {
        for (int i = 0; i < spawnLocations.Count; i++) 
        {
            float j = Random.value;
            if (j > 0.5)
            {
                Instantiate(spawnObject, spawnLocations[i].position, Quaternion.identity);
            }
            Debug.Log(j);
        }
    }
}
