using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveScript : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 10.0f;
    private bool isJumping = false; 
    private Rigidbody rb;
    private Vector3 movement;
    public GameObject camera;
    public AudioListener audioListener;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        movement = Camera.main.transform.TransformDirection(new Vector3(moveHorizontal * speed, 0, moveVertical * speed));
        movement.y = rb.velocity.y;
        if (movement != Vector3.zero ) 
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }
        rb.velocity = movement;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(camera.transform.forward.x, camera.transform.forward.y/10, camera.transform.forward.z) * jumpForce, ForceMode.Impulse);
            Debug.Log("jump");
            isJumping = true; 
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorTest")) 
        {
            isJumping = false;
        }
    }
}
