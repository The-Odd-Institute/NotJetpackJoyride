using UnityEngine;

public class PrefabCoin : MonoBehaviour
{
    [SerializeField] ParticleSystem coinCollectParticle;

    private Animator animator;
    private const float ANIMATION_DELAY_TIME = 1.0f;
    private float delayTimer = default;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("runAnimation", true);
    }

    private void Update()
    {
        UpdateAnimationDelayTimer();
    }

    private void UpdateAnimationDelayTimer()
    {
        if (delayTimer <= 0.0f)
            return;

        delayTimer -= Time.deltaTime;
        if (delayTimer <= 0.0f)
            animator.SetBool("runAnimation", true);
    }

    public void SetRunAnimationTrue()
    {
        animator.SetBool("runAnimation", true);
        // SetRunAnimationFalse() will be called at the end of animation
    }

    public void SetRunAnimationFalse()
    {
        animator.SetBool("runAnimation", false);
        delayTimer = ANIMATION_DELAY_TIME;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        Instantiate(coinCollectParticle.gameObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}