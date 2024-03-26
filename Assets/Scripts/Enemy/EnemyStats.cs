using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("Enemy")]
    public float health;
    public float armorCoef;

    [SerializeField] private GameObject dropResource;


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
        Instantiate(dropResource, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
