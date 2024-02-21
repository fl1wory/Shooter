using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAction : MonoBehaviour
{
    void Start()
    {
        Timer timer = gameObject.AddComponent<Timer>();
        float times = 1.5f;

        timer.DelayAction(PrintMess, times);
    }
    void PrintMess()
    {
        Debug.Log("orrwj[egrieogigkhbdfpedsfr;l'pb[hdfprkmlh;gyp[ngdrokmlgthyfj[ngfjrd mlsftgl[ohk");
    }
}
