using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingScript : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    private float speed;
    private float jumpForce;
    private bool isJumping = false; 
    private Rigidbody rb;
    private Vector3 movement;
    private Camera cam;
    public AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        speed = playerStats.speed;
        jumpForce = playerStats.jumpForce;
    }
    
    

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        cam.transform.forward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        movement = cam.transform.TransformDirection(new Vector3(moveHorizontal, 0, moveVertical)).normalized * speed;
        rb.AddForce(movement, ForceMode.VelocityChange);
        Debug.Log(rb.velocity);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorTest")) 
        {
            isJumping = false;
        }
    }
}
