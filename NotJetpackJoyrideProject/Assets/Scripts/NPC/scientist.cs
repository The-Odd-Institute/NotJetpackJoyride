using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientist : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;

    GameObject player;
    bool playerIsInDetectionRange = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
         
      /*  if(playerIsInDetectionRange && !player.GetComponent<PlayerController>().isOnGround)
        {
            animator.SetBool("DetectedPlayer", true);
            speed *= Random.Range(0, 2) * 2 - 1; //change to random direction
            FlipSprite();
            playerIsInDetectionRange = false;
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.gameObject.GetComponent<PlayerController>().isOnGround)
        {
            animator.SetBool("DetectedPlayer", true);
            speed *= Random.Range(0, 2) * 2 - 1; //change to random direction
            FlipSprite();
            playerIsInDetectionRange = false;
        }
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(Mathf.Sign(-speed), 1, 1);
    }
    private void OnParticleTrigger()
    {
        Debug.Log("has been hitted");

        animator.SetBool("HasBeenHited", true);
        speed = 0;
    }

}

