using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesInventory : MonoBehaviour
{
    [SerializeField] private List<Slot> slots;
    [SerializeField] private float raycastLength = 5f; 

    void Update()
    {
        RaycastPick();
    }

    void RaycastPick()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.TryGetComponent(out Resource r))
                {
                    Pick(hitObject);
                }
            }
        }
    }

    void Pick(GameObject obj)
    {
        foreach(Slot slot in slots)
        {
            if(!slot.hasItem || slot.TryGetComponent(out Resource res))
            {
                slot.SetSlotInf(res);
                break;
            }
        }
        obj.SetActive(false);
    }  
}

