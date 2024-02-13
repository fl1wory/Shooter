using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    public GameObject ballPrefab; 
    public GameObject weapon; 
    public GameObject weaponBullet;
    public float pushForce = 10f;


    public void Shoot()
    {
        GameObject ball = Instantiate(ballPrefab, weaponBullet.transform.position, weapon.transform.rotation); 
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * pushForce, ForceMode.Impulse);
            transform.LookAt(transform.forward);
        }
    }
}
