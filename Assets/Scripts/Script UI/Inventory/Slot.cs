using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Text resourceName;
    [SerializeField] private Image resourceImage;
    [SerializeField] private Text resourceCount;
    public bool hasItem;

    public void SetSlotInf(Resource res)
    {
        resourceName.text = res.resourceName;
        resourceImage.sprite = res.resourceImageSprite;
        resourceCount.text = $"{int.Parse(resourceCount.text) + res.resourceCount}";
        if(resourceName != null && resourceImage != null && resourceCount != null)
        {
            hasItem = true;
        }
        else
        {
            hasItem = false;
        }
    }
}