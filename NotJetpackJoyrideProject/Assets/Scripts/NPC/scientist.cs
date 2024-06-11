using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientist : MonoBehaviour
{
    [SerializeField] private float speed;

    private Animator animator;
    private Rigidbody2D rb;

    bool playerIsInDetectionRange = false;
    bool isDead = false;
    int playerLayer;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        playerLayer = LayerMask.NameToLayer("Player");
    }

    void Update()
    {
        if (isDead)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            return;
        }
        if (speed != 0)
        {
            float moveSpeed = playerIsInDetectionRange ? speed : -speed;
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            Debug.Log("player enter the detection range");
            CheckPlayerFlying(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            CheckPlayerFlying(other);
        }
    }
    private void CheckPlayerFlying(Collider2D other)
    {
        if (!isDead)
        {
            if (!other.gameObject.GetComponent<PlayerController>().GetPlayerIsOnGround())
            {
                if (!playerIsInDetectionRange)
                {
                    playerIsInDetectionRange = true;
                    animator.SetBool("DetectedPlayer", true);
                    ChangeDirection();
                }
            }
            else
            {
                playerIsInDetectionRange = false;
                animator.SetBool("DetectedPlayer", false);
            }
        }
    }
    public void HandleDeath()
    {
        Debug.Log("npc is dead");
        animator.SetBool("HasBeenHited", true);
        isDead = true;
        speed = -10;
    }

    private void ChangeDirection()
    {
        int direction = Random.Range(0, 2) * 2 - 1;
        speed = Mathf.Abs(speed) * direction;

        rb.velocity = new Vector2(speed, rb.velocity.y);

        Debug.Log("Current speed: " + speed);

        FlipSprite();
    }
    private void FlipSprite()
    {    
       transform.localScale = new Vector3(Mathf.Sign(speed), 1, 1);   
    }
}

