using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class clusterGrenadeBullet : Bullet
{
    [SerializeField] private string floorTag = "floorTest";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(floorTag)) 
        {
            StartCoroutine(SeparateGrenade());
        }
    }
}
