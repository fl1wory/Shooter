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
    [Header("Guns and PowerUps")]
    //[SerializeField] private GameObject[] _powerUps;
    [SerializeField] private Inventory guns;

    void Death()
    {
        if(health <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
