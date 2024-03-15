using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Resource")]
public class ResourceScriptableObject : ScriptableObject
{
    public string _ResourceName;
    public GameObject _ResourcePrefab;
    public int _ResourceCount;
    public Sprite _ResourceImageSprite;

    public string ResourceName
    { get { return _ResourceName; } } 

    public int ResourceCount
    { get { return _ResourceCount; } }
        
    public Sprite ResourceImageSprite
    { get { return _ResourceImageSprite; } }

    public GameObject ResourcePrefab 
    { get { return _ResourcePrefab; } }

}
