using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoLevel : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(sceneName);
    }
}
