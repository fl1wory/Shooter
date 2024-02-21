using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeactivateObject : MonoBehaviour
{
    private UnityEvent onEnterCollider;
    
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        if (onEnterCollider == null)
            onEnterCollider = new UnityEvent();

        onEnterCollider.AddListener(Deactivate); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        onEnterCollider.Invoke();
    }

}
