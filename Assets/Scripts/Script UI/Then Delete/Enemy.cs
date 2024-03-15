using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacters
{
    public int health = 100;
    public void Move(Vector3 direction)
    {

    }
    public int Attack()
    {
        return 15;
    }
    public void TakeDamage(int damage)
    {

    }
}
