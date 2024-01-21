using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public void DelayAction(Action action,float delay)
    {
         StartCoroutine(ActionTime(action, delay));
    }
    IEnumerator ActionTime(Action action,float delay)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
