using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingGrenades : MonoBehaviour
{
    public float damagePerPounce = 10f;
    public int maxBounces = 5;
    private int remainingBounces;
    void Start()
    {
        remainingBounces = maxBounces;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (remainingBounces > 0)
        {
            remainingBounces--;
            damagePerPounce *= 1.2f;
            Debug.Log(damagePerPounce);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
