using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scientist : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -10)
        {
            //Create a pool
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("colided");

        if (other.CompareTag("Player"))
        {
            animator.SetBool("DetectedPlayer", true);
            speed *= Random.Range(0, 2) * 2 - 1; //change to random direction
            FlipSprite();
        }
    }
    private void FlipSprite()
    {
        transform.localScale = new Vector3(Mathf.Sign(speed), 1, 1);
    }

}
