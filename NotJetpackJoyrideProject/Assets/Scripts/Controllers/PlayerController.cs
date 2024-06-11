using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum ForceType
{
    Gravity,
    Jetpack,
    Jump
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ForceMode2D forceMode;
    [SerializeField] private GameObject jetpack;
    [SerializeField] private float jumpForce; // 25
    [SerializeField] private float jetpackForce;
    [SerializeField] private float gravityForce; // -9.8

    [SerializeField] private PhysicsMaterial2D bounceMaterial;

    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;
    private bool isOnGround = true;
    private bool jetpackEnabled = false;
    private Animator animator;
    private GameManager gameManager;
    private ParticleSystem bullets;


    [SerializeField]
    private float boostFactor = 1.0f;
    private float boost = 1.0f;

    private bool playerIsDead = default;
    private string locationOfScreenshot = "NotJetpackJoyrideProject\\Assets";

    private ForceType forceType = ForceType.Gravity;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        bullets = jetpack.GetComponent<ParticleSystem>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        animator.SetBool("IsGrounded", isOnGround);
        animator.SetBool("jetpackEnabled", jetpackEnabled);
        // InvertHandler();

        if (playerIsDead)
        {
            forceType = ForceType.Gravity;
            if (gameManager.GetScrollSpeed() <= 0)
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



        // apply the force
        ApplyForce();
    }

    private void ApplyForce()
    {
        float y;
        switch (forceType)
        {
            case ForceType.Jetpack:
                y = jetpackForce * Time.deltaTime;
                // Debug.Log ("In Jet mode");

                break;
            case ForceType.Jump:
                y = jumpForce * Time.deltaTime;
                // Debug.Log ("In JUMP mode");

                break;
            default:
                y = gravityForce * Time.deltaTime;
                // Debug.Log ("In GRAVITY mode");

                break;
        }

        Vector2 force = new Vector2(0, y * boost);
        playerRigidbody.AddForce(force, forceMode);
    }

    private void DesktopInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isOnGround) // on ground
                forceType = ForceType.Jump;

            else // mid air
            {
                jetpackEnabled = true;
                forceType = ForceType.Jetpack;
            }
            boost = 1;
        }
        else
        {
            boost = 1;
            forceType = ForceType.Gravity;
            jetpackEnabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isOnGround)
            {
                boost = boostFactor;

                jetpackEnabled = true;
                forceType = ForceType.Jetpack;
            }
        }
    }
    private void MobileInput()
    {
        // Check if there is at least one touch
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

           if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                if (isOnGround) // on ground
                    forceType = ForceType.Jump;
                else // mid air
                {
                    jetpackEnabled = true;
                    forceType = ForceType.Jetpack;
                }
                boost = 1;
            }
            else
            {
                boost = 1;
                forceType = ForceType.Gravity;
                jetpackEnabled = false; 
            }


            // Check the touch phase
            if (touch.phase == TouchPhase.Began)
            {
                if (!isOnGround)
                {
                    boost = boostFactor;

                    jetpackEnabled = true;
                    forceType = ForceType.Jetpack;
                }
            }
        }
        else
            {
                boost = 1;
                forceType = ForceType.Gravity;
                jetpackEnabled = false; 
            }
    }

    private void KillPlayer()
    {
        animator.SetLayerWeight(1, 1);
        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.gravityScale = 2.5f;
        playerRigidbody.sharedMaterial = bounceMaterial;
        Destroy(bullets);
        gameManager.CaptureScreenshot(locationOfScreenshot, 1);
        playerIsDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
            isOnGround = true;

        // KEEP
        if (collision.gameObject.tag == "Obstacle")
            KillPlayer();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
            isOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isOnGround = false;
        }
    }

    public bool GetJetpackStatus() => jetpackEnabled;
    public bool GetPlayerDeathStatus() => playerIsDead;
}