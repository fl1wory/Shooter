using UnityEngine;

interface ICharacters
{
   //public int health { get; set; }
    void Move(Vector3 direction);
    int Attack();
    void TakeDamage(int damage);
}