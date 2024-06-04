using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ForceType
{
    Gravity,
    Rocket,
    Jump
}

public class PlayerController : MonoBehaviour
{

    [SerializeField] private GameObject jetpack;
    [SerializeField] private float jumpForce; // 25
    [SerializeField] private float rocketForce;
    [SerializeField] private float maxVerticalSpeed;
    [SerializeField] private float gravity; // -9.8

    [SerializeField] bool invert = false;
    [SerializeField] private PhysicsMaterial2D bounceMaterial;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;
    private bool isOnGround = false;
    private bool isJumping = false;
    // private bool midAir = false;
    private bool jetpackEnabled = false;
    private int invertMod = 1;
    private Animator animator;
    private GameManager gameManager;
    private ParticleSystem boolets;

    private const float TimeToDeathScreen = 3.0f;
    private float timer = default;
    private bool playerIsDead = default;
    private string locationOfScreenshot = "NotJetpackJoyrideProject\\Assets";

    private ForceType forceType = ForceType.Gravity;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        boolets = jetpack.GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void FixedUpdate()
    {
        float y;
        switch (forceType)
        {
            case ForceType.Gravity:
                y = gravity * Time.fixedDeltaTime;
                break;
            case ForceType.Rocket:
                y = rocketForce * Time.fixedDeltaTime;
                break;
            case ForceType.Jump:
                y = jumpForce * Time.fixedDeltaTime;
                break;
            default:
                y = 0;
                break;
        }

        Vector2 force = new Vector2(0, y);
        playerRigidbody.AddForce(force, ForceMode2D.Force);
    }

    void Update()
    {
        animator.SetBool("IsGrounded", isOnGround);
        animator.SetBool("jetpackEnabled", jetpackEnabled);
       // InvertHandler();

        if (playerIsDead)
        {
            forceType = ForceType.Gravity;
            if(gameManager.GetScrollSpeed() <= 0)
                gameManager.LoadDeathScreen();
        }

        if (!playerIsDead)
        {
            #if UNITY_EDITOR || UNITY_STANDALONE
                DesktopInput();
            #elif UNITY_IOS || UNITY_ANDROID
                MobileInput();
            #endif
        }

       // LimitVerticalSpeed();
    }


 
    private void ApplyGravity()
    {
        Vector2 gravity = new Vector2(0, this.gravity * Time.deltaTime);
        playerRigidbody.AddForce(gravity, ForceMode2D.Impulse);
    }
    private void LimitVerticalSpeed()
    {
        int sign = 0;
        if (playerRigidbody.velocity.y > maxVerticalSpeed) sign = 1;
        else if (playerRigidbody.velocity.y < -maxVerticalSpeed) sign = -1;
            
        playerRigidbody.velocity = new Vector2( playerRigidbody.velocity.x, 
                                                maxVerticalSpeed * sign);
    }
    private void DesktopInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isOnGround) // mid air
            {
                // use jetpack
                jetpackEnabled = true;
                forceType = ForceType.Rocket;
            }
            else // on the ground
            {
                isOnGround = false; 
                forceType = ForceType.Jump;
                // Jump();
            }
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            // ActivateJetpack();
            jetpackEnabled = true;
            forceType = ForceType.Rocket;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            jetpackEnabled = false;
            // if (!isOnGround)
        }
        else
        {
            forceType = ForceType.Gravity;
        }
        
        //ApplyGravity();

        // if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !invert)
        //     Jump();
        
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     isJumping = false;
        //     jetpackEnabled = false;
        // }

    }
    private void MobileInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && isOnGround && !invert)
            {
            }
            else if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved))
            {

            }
            if (touch.phase == TouchPhase.Ended)
            {

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

    private void Jump()
    {
        Debug.Log("Jumping");
        Vector2 jump = new Vector2(0, jumpForce * invertMod * Time.deltaTime);

        playerRigidbody.AddForce(jump, ForceMode2D.Impulse);
        // isJumping = true; 

        // jump can only be called when on the ground
        isOnGround = false; 
    }

    private void ActivateJetpack()
    {
        float boostFactor = 1.0f;
        if (playerRigidbody.velocity.y < 0) // Adds small boost if falling
            boostFactor += Mathf.Abs(playerRigidbody.velocity.y) / maxVerticalSpeed;
        

        Vector2 force = new Vector2(0, rocketForce * invertMod * boostFactor);

        playerRigidbody.AddForce(force, ForceMode2D.Force);
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
        if (collision.gameObject.layer == 6)  isOnGround = true;
        if (collision.gameObject.tag == "Obstacle") KillPlayer();
    }

    // private void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (collision.gameObject.layer == 6) isOnGround = false;
    // }

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
}