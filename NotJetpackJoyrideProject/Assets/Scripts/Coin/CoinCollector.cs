using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;
    }
}