using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public float speed = 3.0f; 

    void Update()
    {
        
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

        
        Vector3 newPosition = transform.position + randomDirection * speed * Time.deltaTime;

        
        transform.position = newPosition;
    }
}
