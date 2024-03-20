using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class bulletScript : MonoBehaviour
{
    public string wallTag = "floorTest";
    [SerializeField] private string playerTag = "Player";
    public GameObject EXPLOSION;
    public float damage;
    [SerializeField] private bool isCluster = false;
    [SerializeField] private GameObject clusterBullet;



    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        EXPLOSION.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, 1);
        gameObject.GetComponent<SphereCollider>().enabled = true;
        if (isCluster)
        {
            for(int i = 0; i < 1; i++)
            {
                //instantiate cluster bullet and add force to in in random direction
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                Rigidbody rb = clusterBullet.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddForce(transform.forward * damage, ForceMode.Impulse);
                }
            }
        }
    }
    /*
    public void explode(float delay)
    {
        EXPLOSION.GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, delay);
    }*/
    
}
