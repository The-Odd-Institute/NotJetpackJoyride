using UnityEngine;

public class CoinKillBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PrefabCoin>(out var coin))
        {
            coin.BackToCoinPool();
        }
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
    }
}