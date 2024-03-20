using UnityEngine;
using UnityEngine.UI;


interface IResource
{
    public string resourceName { get; set; }
    public GameObject resourcePrefab { get; set; }
    public int resourceCount { get; set; }
    public Image resourceImage { get; set; }
    public Sprite resourceImageSprite { get; set; }

    //public ScriptableObject resourceScriptableObject { get; set; }


    void ShowOnUI();
}
