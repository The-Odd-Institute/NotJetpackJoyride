using UnityEngine;

public class PlayerShadowController : MonoBehaviour
{
    private void Update()
    {
        if (transform.parent.transform.localPosition.y < -180.0f)
            return;

        float delta = Mathf.Abs(transform.parent.transform.localPosition.y - (-176.0f));
        float scale = delta / 4;
        scale = Mathf.Clamp(scale, 0.1f, 1.0f);

        transform.localScale = new Vector3(scale, scale, scale);
    }
}