using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesInventory : MonoBehaviour
{
    [SerializeField] private List<Resource> resoueces;
    [SerializeField] private List<Resource> resouecesInvenory;
    [SerializeField] private List<Text> resourceName;
    [SerializeField] private List<Image> resourceImage;
    [SerializeField] private List<Text> resourceCount;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Resource resource))
        {
            // add a resource to the inventory
            Pick(resource, resourceName[resourceName.Count - 1], resourceImage[resourceImage.Count - 1], resourceCount[resourceCount.Count - 1]);
        }
    }

    void Pick(Resource obj, Text text, Image image, Text count)
    {
        obj.gameObject.SetActive(false);
        resouecesInvenory.Add(obj);
        //text.text = obj.GetComponent<Resource>().resourceName;
        //image.sprite = obj.GetComponent<Resource>().resourceImageSprite;
        //count.text = $"{int.Parse(count.text) + obj.GetComponent<Resource>().resourceCount}";
    }

    void Delete(Resource obj)
    {
        resouecesInvenory.Remove(obj);
    }
}
