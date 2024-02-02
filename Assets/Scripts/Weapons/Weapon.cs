using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : MonoBehaviour
{
    [SerializeField]public float damage;
    [SerializeField]public float speed;
    [SerializeField]public string name;
    [SerializeField]public int ammosCount;
    [SerializeField]public int ammosCountMax;
    [SerializeField]public GameObject bulletPrefab;
    [SerializeField]public ParticleSystem shootEffect;
    [SerializeField]public Transform shootPoint;


    public void Shoot(GameObject weaponGameObject)
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation); 
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(weaponGameObject.transform.forward * speed, ForceMode.Impulse);
            weaponGameObject.transform.LookAt(weaponGameObject.transform.forward);
            shootEffect.Play();
        }
    }











    /*
    public float Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int AmmosCount
    {
        get { return _ammosCount; }
        set { _ammosCount = value; }
    }

    public int AmmosCountMax
    {
        get { return _ammosCountMax; }
        set { _ammosCountMax  = value; }
    }

    public GameObject BulletPrefab
    {
        get { return _bulletPrefab; }
        set { _bulletPrefab = value; }
    }

    public GameObject ShootEffect
    {
        get { return _shootEffect; }
        set { _shootEffect = value; }
    }

    public Transform ShootPoint
    {
        get { return _shootPoint; }
        set { _shootPoint = value; }
    }
    */
}