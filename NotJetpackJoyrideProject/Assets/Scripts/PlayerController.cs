using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpTime;
    [SerializeField] private float rocketForce;
    [SerializeField] private Collider2D groundCheck;
    [SerializeField] private float downwardForce;
    [SerializeField] bool invert = false;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;
    private bool isOnGround = false;
    private bool isJumping = false;
    private int invertMod = 1;
    private float currentJumpTime = 0;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        InvertHandler(); //sets invertMod to 1 or -1 to invert forces
        InputHandler();
        JumpHandler();

        if(!Input.GetKey(KeyCode.Space) && !isOnGround && !isJumping) // 'gravity' but not accelerating
        {
            playerRigidbody.AddForce(new Vector2(0, -invertMod * downwardForce * Time.deltaTime), ForceMode2D.Impulse);
        }
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !invert) //player jump, gets higher more quickly
        {
            playerRigidbody.AddForce(new Vector2(0, jumpForce * invertMod), ForceMode2D.Force);
            isJumping = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = false;
        }
        else if (Input.GetKey(KeyCode.Space) && !isOnGround && !isJumping && currentJumpTime <= 0) //rocket upwards, not on the ground
        {
            playerRigidbody.AddForce(new Vector2(0, rocketForce * invertMod), ForceMode2D.Force);
        }
    }

    private void InvertHandler()
    {
        if (!invert)
        {
            invertMod = 1;
            playerTransform.transform.rotation = Quaternion.Euler(0, 0, 0);
            return;
        }

        invertMod = -1; // invert mod is just to flip the gravity and forces when inverting.
        playerTransform.transform.rotation = Quaternion.Euler(0, 180, 180);
        
    }

    private void JumpHandler()
    {
        if(!isJumping) 
        { 
            return;
        }

        if (!Input.GetKey(KeyCode.Space) && !isOnGround)
        {
            currentJumpTime = 0;
            isJumping = false;
        }
        
        currentJumpTime += Time.deltaTime;
        if (currentJumpTime > jumpTime)
        {
            currentJumpTime = 0;
            isJumping = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6) // 6 is ground layer
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6) // 6 is ground layer
        {
            isOnGround = false;
        }
    }
}
