using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTargetsDamage : MonoBehaviour
{
    [SerializeField] private Text damageText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            damageText.text = $"{collision.gameObject.GetComponent<BulletStats>().damage}";
        }
    }
}
