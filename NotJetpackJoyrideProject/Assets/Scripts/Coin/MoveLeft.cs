using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float moveSpeed = default;
    public float MoveSpeed {  get { return moveSpeed; } set {  moveSpeed = value; } }

    private bool isMoving = default;
    public bool IsMoving { get {  return isMoving; } set {  isMoving = value; } }

    private void Update()
    {
        if (isMoving)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

        if (transform.childCount == 0)
            Destroy(gameObject);
    }
}