using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Player stats")]
    [SerializeField] private string name;
    [SerializeField] private float healthChange;
    [SerializeField] private int dashCountChange;
    [SerializeField] private float speedChange;
    [SerializeField] private float jumpForceChange;
    [SerializeField] private float armorCoefChange;
    [SerializeField] private PlayerStats playerStats;


    [Header("Weapon stats")]
    [SerializeField] private Weapon weapon;
    [SerializeField] private float reloadTimeChange;
    [SerializeField] private float damageChange;
    [SerializeField] private float buletSpeedChange;
    [SerializeField] private int ammoCountChange;
    [SerializeField] private int ammoCountMaxChange;
    public bool isPicked;
    public void Change()
    {
        playerStats.health += healthChange;
        playerStats.dashCount += dashCountChange;
        playerStats.speed += speedChange;
        playerStats.jumpForce += jumpForceChange;
        playerStats.armorCoef += armorCoefChange;

        weapon.reloadTime += reloadTimeChange;
        weapon.damage += damageChange;
        weapon.speed += buletSpeedChange;
        weapon.ammoCount += ammoCountChange;
        weapon.ammoCountMax = ammoCountMaxChange;
    }
}
