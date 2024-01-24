using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScript : MonoBehaviour
{
    [SerializeField] UnityEvent onPlayEffect;
    private void OnButtonClick()
    {
        onPlayEffect.Invoke();
    }
}
