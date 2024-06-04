using UnityEngine;

public class AnimationTriggerBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

      //  Debug.Log("Insoide tyhe funct");
         
        if (collision.gameObject.TryGetComponent<PrefabCoin>(out var coin))
        {
          //  Debug.Log("Try worked");

            coin.SetRunAnimationTrue();
        }
    }
}