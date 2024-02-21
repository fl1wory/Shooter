using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItems : MonoBehaviour
{
    public delegate void ItemCollection(string itemName);
    public static event ItemCollection OnItemCollection;

    public void CollectionItems(string name)
    {
        OnItemCollection?.Invoke(name);
    }

    
}
