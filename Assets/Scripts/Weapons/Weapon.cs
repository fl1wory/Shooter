using System.Collections;
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
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected ParticleSystem shootEffect;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected GameObject weaponGameObject;
    [SerializeField] protected Text ammoCountText;
    [SerializeField] protected Text ammoCountMaxText;
    [SerializeField] protected AudioSource ShootSoundAudioSource;
    [SerializeField] private AudioSource ReloadSoundAudioSource;
    

    ////////* tech variables */////////
    private bool isReloading = true;



    private void Start()
    {
        ammoCountMaxText.text = ammoCountMax.ToString();
        ammoCountText.text = ammoCount.ToString();
        StartCoroutine(Reload());
    }

    public void ReloadF()
    {
        StartCoroutine(Reload());
    }

    private void Update()
    {
        ammoCountText.text = ammoCount.ToString();
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
                Debug.Log("shoot");
                rb.AddForce(shootPoint.transform.up * speed, ForceMode.Impulse);
                shootEffect.Play();
                ammoCount--;
                ammoCountText.text = ammoCount.ToString();
                ShootSoundAudioSource.Play();
            }
        }
    }

    private IEnumerator Reload()
    {
        if (ammoCount <= 0 && !isReloading)
        {
            isReloading = true;
            Debug.Log("reloading");
            yield return new WaitForSeconds(reloadTime);
            ammoCount = ammoCountMax;
            StartCoroutine(Reload());
            ReloadSoundAudioSource.Play();
        }
        else
        {
            isReloading = false;
            yield return null;
            StartCoroutine(Reload());
        }
    }

}