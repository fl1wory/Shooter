using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    [Header("Player")]
    public float health;
    public int dashCount;
    public  float speed;
    public float jumpForce;
    public float armorCoef;

    [Header("UI")]
    [SerializeField] private Slider hpSlider;
    private void Start()
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }

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
        hpSlider.value = health;
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
