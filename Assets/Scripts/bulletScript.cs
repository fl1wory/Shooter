using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public string wallTag = "floorTest";
    public GameObject EXPLOSION;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == wallTag)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            //EXPLOSION.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
        }
    }
}
