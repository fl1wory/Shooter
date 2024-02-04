using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon")]
public class Weapon : MonoBehaviour
{
    public float reloadTime;
    public float damage;
    public float speed;
    public string weaponName;
    public int ammoCount;
    public int ammoCountMax;
    public GameObject bulletPrefab;
    public ParticleSystem shootEffect;
    public Transform shootPoint;
    public GameObject weaponGameObject;
    public Text ammoCountText;
    public Text ammoCountMaxText;
    

    ////////* Òευν³χν³ ημ³νν³*/////////
    private bool isReloading = true;



    private void Start()
    {
        ammoCountMaxText.text = ammoCountMax.ToString();
        ammoCountText.text = ammoCount.ToString();
        StartCoroutine(Reload());
    }

    public void ShootGrenade(GameObject weaponGameObject)
    {
        if (!isReloading) 
        { 
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation); 
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //weaponGameObject.transform.LookAt(weaponGameObject.transform.forward);
                rb.AddForce(shootPoint.transform.up * speed, ForceMode.Impulse);
                shootEffect.Play();
                ammoCount--;
                ammoCountText.text = ammoCount.ToString();
            }
        }
    }

    private IEnumerator Reload()
    {
        if (ammoCount <= 0 && !isReloading)
        {
            ammoCount = ammoCountMax;
            isReloading = true;
            Debug.Log("reloading");
            yield return new WaitForSeconds(reloadTime);
            StartCoroutine(Reload());
        }
        else
        {
            isReloading = false;
            yield return null;
            StartCoroutine(Reload());
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