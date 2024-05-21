using UnityEngine;

public class ObstacleKillBox : MonoBehaviour
{
    [SerializeField] private BackgroundControllerNew backgroundController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PrefabCoin>(out var coin))
        {
            coin.BackToCoinPool();
        }
        else if(collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.transform.parent.gameObject);
        }
        else if (collision.gameObject.CompareTag("Background"))
        {
            backgroundController.CreateCell();
            Destroy(collision.gameObject);
        }
    }
}