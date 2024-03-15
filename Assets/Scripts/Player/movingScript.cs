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

    void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement.Normalize();        
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = movement * speed * Time.fixedDeltaTime;
        rb.velocity = moveDirection * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorTest")) 
        {
            isJumping = false;
        }
    }
}
