using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundCellController : MonoBehaviour
{
    public enum CellType { Start, Body, End,};
    [SerializeField] private CellType cell = CellType.Start;
    public CellType Cell { get { return cell; } }

    [SerializeField] private float moveSpeed = default;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }

    [SerializeField] private Transform cellEnding = default;
    public Transform CellEnding { get { return cellEnding; } }

    [SerializeField] private Transform ceilingList = default;
    [SerializeField] private Transform groundList = default;
    [SerializeField] private Transform backGround1 = default;
    [SerializeField] private Transform backGround3 = default;

    private const int Y_MIN = -4;
    private const int Y_MAX = 5;
    private const int BG3_THRESHOLD_MAX = 0;
    private const int BG3_THRESHOLD_MIN = -2;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        moveSpeed = gameManager.GetScrollSpeed();
        Vector3 newPosition = transform.position;
        newPosition.x -= moveSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void ResetCell()
    {
        backGround1.position = Vector3.zero;
        backGround3.gameObject.SetActive(false);
    }

    private void RandomFront(Transform frontList)
    {
        int random = Random.Range(0, frontList.childCount);

        foreach (Transform ceiling in frontList)
            ceiling.gameObject.SetActive(false);

        frontList.GetChild(random).gameObject.SetActive(true);
    }

    private void GenerateCellStart()
    {
        backGround1.localPosition = new Vector3(0.0f, backGround1.position.y + BG3_THRESHOLD_MIN, 0.0f);

        if (backGround3.gameObject.activeInHierarchy == false)
            backGround3.gameObject.SetActive(true);

        // Random Ceiling
        RandomFront(ceilingList);

        // Random Ground
        RandomFront(groundList);
    }

    private void GenerateCellBody()
    {
        // Random Background1 position
        int random = Random.Range(Y_MIN, Y_MAX);
        backGround1.localPosition = new Vector3(0.0f, backGround1.position.y + random, 0.0f);

        if (random >= BG3_THRESHOLD_MIN && random <= BG3_THRESHOLD_MAX)
            backGround3.gameObject.SetActive(true);

        // Random Ceiling
        RandomFront(ceilingList);

        // Random Ground
        RandomFront(groundList);
    }

    private void GenerateCellEnd()
    {
        // Random Background1 position
        int random = Random.Range(Y_MIN, Y_MAX);
        backGround1.localPosition = new Vector3(0.0f, backGround1.position.y + random, 0.0f);

        if (random >= BG3_THRESHOLD_MIN && random <= BG3_THRESHOLD_MAX)
            backGround3.gameObject.SetActive(true);

        // Random Ceiling
        RandomFront(ceilingList);

        // Random Ground
        RandomFront(groundList);
    }

    public void GenerateCell()
    {
        ResetCell();

        switch (cell)
        {
            case CellType.Start:
                GenerateCellStart();
                break;
            case CellType.Body:
                GenerateCellBody();
                break;
            case CellType.End:
                GenerateCellEnd();
                break;
            default:
                break;
        }
    }
}