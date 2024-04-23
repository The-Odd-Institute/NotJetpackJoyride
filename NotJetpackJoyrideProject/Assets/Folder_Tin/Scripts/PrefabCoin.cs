using UnityEngine;

public class PrefabCoin : MonoBehaviour
{
    [SerializeField] ParticleSystem coinCollectParticle;

    private Animator animator;
    private const float ANIMATION_DELAY_TIME = 0.75f;
    private float delayTimer = default;

    private Transform parent = default;
    public Transform Parent { set => parent = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
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

    public void BackToCoinPool()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = Vector3.zero;
        gameObject.transform.SetParent(parent);
    }

    private void CollectCoin()
    {
        Instantiate(coinCollectParticle.gameObject, transform.position, Quaternion.identity);
        BackToCoinPool();
    }
}