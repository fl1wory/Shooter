using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<GameObject> objects;
    public List<Weapon> weapons;
    public List<GameObject> weaponIcons;
    [HideInInspector]public int index = 0;

    void Update()
    {

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");


        if (scrollInput != 0)
        {

            objects[index].SetActive(false);
            weaponIcons[index].SetActive(false);
            if (scrollInput > 0)
            {
                index = (index + 1) % objects.Count;
            }
            else
            {
                index--;
                if (index < 0)
                {
                    index = objects.Count - 1;
                }
            }

            objects[index].SetActive(true);
            weaponIcons[index].SetActive(true);
            weapons[index].ReloadF();
        }
    }
}
