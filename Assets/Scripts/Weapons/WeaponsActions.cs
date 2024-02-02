using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsActions : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    protected float damage;

    [SerializeField] private string name;

    void Start()
    {
        damage = weapon.damage;
    }

    void Update()
    {

    }
}
