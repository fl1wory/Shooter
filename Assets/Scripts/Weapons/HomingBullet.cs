using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{

    [SerializeField] private string floorTag = "floorTest";
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == floorTag)
        {
            HomingGrenage();
        }
    }
}
