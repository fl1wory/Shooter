using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingGrenades : MonoBehaviour
{
    public float damagePerPounce;
    public int maxBounces = 5;
    private int remainingBounces;
    [SerializeField] private bulletScript grenades;
    void Start()
    {
        remainingBounces = maxBounces;
    }

    private void OnCollisionEnter(Collision collision)
    {
        grenades.explode(2);
        if (remainingBounces >= 0)
        {
            remainingBounces--;
            damagePerPounce *= 1.2f;
            Debug.Log(damagePerPounce);

        }
        else
        {
            grenades.explode(0);
        }
    }
}
