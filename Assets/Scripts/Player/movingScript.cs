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
        movement = cam.transform.TransformDirection(new Vector3(moveHorizontal * speed, 0, moveVertical * speed));
        rb.velocity = movement;
        Debug.Log(rb.velocity);
        //audioSource.volume = movement != Vector3.zero ? 1 : 0;
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z) * jumpForce, ForceMode.Impulse);
            Debug.Log("jump");
            isJumping = true; 
        }*/
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floorTest")) 
        {
            isJumping = false;
        }
    }
}
