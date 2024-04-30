using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float rocketForce;
    [SerializeField] private float maxVerticalSpeed;
    [SerializeField] private float downwardForce;
    [SerializeField] bool invert = false;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;
    private bool isOnGround = false;
    private bool isJumping = false;
    private bool jetpackEnabled = false;
    private int invertMod = 1;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetBool("IsGrounded", isOnGround);
        animator.SetBool("jetpackEnabled", jetpackEnabled);
        InvertHandler();
        InputHandler();
        TouchInputHandler();
        LimitVerticalSpeed();

        if (!Input.GetKey(KeyCode.Space) && !isOnGround && !isJumping)
        {
            ApplyGravity();
        }
    }
    private void ApplyGravity()
    {
        playerRigidbody.AddForce(new Vector2(0, -invertMod * downwardForce * Time.deltaTime), ForceMode2D.Impulse);
    }
    private void LimitVerticalSpeed()
    {
        float currentVerticalSpeed = playerRigidbody.velocity.y;
        if (currentVerticalSpeed > maxVerticalSpeed)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, maxVerticalSpeed);
        }
        else if (currentVerticalSpeed < -maxVerticalSpeed)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, -maxVerticalSpeed);
        }
    }
    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !invert)
        {
            StartJump();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            ActivateJetpack();
            jetpackEnabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            jetpackEnabled = false;
        }

    }
    private void TouchInputHandler()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && isOnGround && !invert)
            {
                StartJump();
            }
            else if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && !isOnGround)
            {
                ActivateJetpack();
                jetpackEnabled = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isJumping = false;
                jetpackEnabled = false;
            }
        }
    }

    private void StartJump()
    {
        playerRigidbody.AddForce(new Vector2(0, jumpForce * invertMod), ForceMode2D.Impulse);
        isJumping = true; 
        isOnGround = false; 
    }

    private void ActivateJetpack()
    {
        float boostFactor = 1.0f;
        if (playerRigidbody.velocity.y < 0) // Adds small boost if falling
        {
            boostFactor += Mathf.Abs(playerRigidbody.velocity.y) / maxVerticalSpeed;
        }
        playerRigidbody.AddForce(new Vector2(0, rocketForce * invertMod * boostFactor), ForceMode2D.Force);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isOnGround = true;
            isJumping = false; // We reset isJumping here when we detect ground contact
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isOnGround = false;
        }
    }
}