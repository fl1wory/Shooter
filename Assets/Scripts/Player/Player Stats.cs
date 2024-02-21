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
    [Header("Guns and PowerUps")]
    [SerializeField] private Weapon ClusterWeapon;

    void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.name == "CGMain" || other.gameObject.name == "CGSeprate")
        {
            health -= ClusterWeapon.damage / armorCoef;
            Debug.Log(health);
        }
    }


    void GetDamage(float damage)
    {
        health -= damage * armorCoef;
        Debug.Log(health);
    }

    void Death()
    {
        if(health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
