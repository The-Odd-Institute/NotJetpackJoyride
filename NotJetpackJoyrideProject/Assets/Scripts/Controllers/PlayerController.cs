using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject jetpack;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rocketForce;
    [SerializeField] private float maxVerticalSpeed;
    [SerializeField] private float downwardForce;
    [SerializeField] bool invert = false;
    [SerializeField] private PhysicsMaterial2D bounceMaterial;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;
    private bool isOnGround = false;
    private bool isJumping = false;
    private bool jetpackEnabled = false;
    private int invertMod = 1;
    private Animator animator;
    private GameManager gameManager;
    private ParticleSystem boolets;

    private const float TimeToDeathScreen = 3.0f;
    private float timer = default;
    private bool playerIsDead = default;
    private string locationOfScreenshot = "NotJetpackJoyrideProject\\Assets";
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        boolets = jetpack.GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        animator.SetBool("IsGrounded", isOnGround);
        animator.SetBool("jetpackEnabled", jetpackEnabled);
        InvertHandler();
        if(!playerIsDead)
        {
            InputHandler();
            TouchInputHandler();
        }
        LimitVerticalSpeed();
        if (!Input.GetKey(KeyCode.Space) && !isOnGround && !isJumping)
        {
            ApplyGravity();
        }

        if (playerIsDead)
        {
            if(gameManager.GetScrollSpeed() <= 0)
            {
                gameManager.LoadDeathScreen();
            }
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
            else if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved))
            {
                ActivateJetpack();
                jetpackEnabled = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                isJumping = false;
                jetpackEnabled = false;
            }
        }
    }

    private void KillPlayer()
    {
        timer = 0.0f;
        animator.SetLayerWeight(1, 1);
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.gravityScale = 2.5f;
        playerRigidbody.sharedMaterial = bounceMaterial;
        Destroy(boolets);
        gameManager.CaptureScreenshot(locationOfScreenshot, 1);
        playerIsDead = true;
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
        Debug.Log("Inside the trigger");
        if (collision.gameObject.layer == 6)
        {
            isOnGround = true;
            isJumping = false; // We reset isJumping here when we detect ground contact
        }

        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("detected");
            KillPlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isOnGround = false;
        }
    }

    public bool GetJetpackStatus()
    {
        if(jetpackEnabled)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool GetPlayerDeathStatus()
    {
        if (playerIsDead)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool GetPlayerIsOnGround()
    {
        return isOnGround;
    }
}