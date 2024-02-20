using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    
    [Header("Cluster")]
    public GameObject objectToSpawn; 
    public int numberOfObjectsToSpawn = 6; 
    public float pushForce = 10f;

    [Header("Homing")]
    public float rotationAngle = 90f;
    public IEnumerator SeparateGrenade()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
            Vector3 pushDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode.Impulse);
        }
        yield return new WaitForSeconds(1);
    }
}
