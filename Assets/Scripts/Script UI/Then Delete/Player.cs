using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour, ICharacters
{
    public int health { get; set; }
    public void Move(Vector3 direction)
    {
  
    }
    public int Attack()
    {
        return 15;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent<ICharacters>(out var character))
        {
            TakeDamage(character.Attack());
        }
    }
}
