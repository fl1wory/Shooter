using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTargetsDamage : MonoBehaviour
{
    [SerializeField] private TextMesh damageText;
    //змінив Text на Text Mesh щоб простіше 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            damageText.text = $"{collision.gameObject.GetComponent<BulletStats>().damage}";
        }
    }
}
