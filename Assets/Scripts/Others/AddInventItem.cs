using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInventItem : MonoBehaviour
{
    private void OnEnable()
    {
        CollectItems.OnItemCollection += ItemCollected;    
    }
    private void OnDisable()
    {
        CollectItems.OnItemCollection -= ItemCollected;

    }
    void Update()
    {
       if (Input.GetKey(KeyCode.Space))
       {
            GetComponent<CollectItems>().CollectionItems("Items");
       } 
    }
    private void ItemCollected(string itemName)
    {
        Debug.Log(itemName);
    }
}
