using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> powerUps;
    [SerializeField] private List<string> powerUpsTags;
    private void OnCollisionEnter(Collision collision)
    {
        if(powerUpsTags.Contains(collision.gameObject.tag)) 
        {
            Pick(collision.gameObject);
        }
    }

    void Pick(GameObject obj)
    {
        obj.SetActive(false);
        powerUps.Add(obj);
        obj.GetComponent<PowerUp>().Change();
    }

    void Delete(GameObject obj)
    {
        powerUps.Remove(obj);
    }
}
