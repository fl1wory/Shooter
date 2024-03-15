using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
public class PlayerStats : MonoBehaviour
{
    [Header("Player")]
    public float health;
    public int dashCount;
    public  float speed;
    public float jumpForce;
    public float armorCoef;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet") && other.gameObject.TryGetComponent<bulletScript>(out bulletScript bulletScr))
        {
            GetDamage(bulletScr.damage);
        }
    }

    public void GetDamage(float damage)
    {
        if (armorCoef <= 0)
        {
            armorCoef = 1;
        }
        health -= damage / armorCoef;
        Debug.Log(health);
    }

    void Update()
    {
        if(health <= 0) 
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
}
