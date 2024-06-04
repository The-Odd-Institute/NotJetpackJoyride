using UnityEngine;

public class AnimationTriggerBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PrefabCoin>(out var coin))
            coin.SetRunAnimationTrue();
    }
}