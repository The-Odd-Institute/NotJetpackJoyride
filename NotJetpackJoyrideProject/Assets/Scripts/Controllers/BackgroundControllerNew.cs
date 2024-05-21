using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BackgroundControllerNew : MonoBehaviour
{
    [SerializeField] private GameObject bGCell_Start = default;
    [SerializeField] private GameObject bGCell_Body = default;
    [SerializeField] private GameObject bGCell_End = default;
    [SerializeField] private float moveSpeed = default;
    [SerializeField] private Transform currentCellEnding = default;

    private const int SECTION_LENGTH_MIN = 2;
    private const int SECTION_LENGTH_MAX = 5;
    private bool newSection = default;
    private int cellCount = default;
    private int indexSortingOrder = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            CreateCell();
    }

    private void CreateCell(GameObject cellToCreate, Vector3 position)
    {
        GameObject cell = Instantiate(cellToCreate, position, Quaternion.identity, transform);

        SortingGroup group = cell.GetComponent<SortingGroup>();
        group.sortingOrder = indexSortingOrder;

        BackgroundCellController cellController = cell.GetComponent<BackgroundCellController>();

        cellController.MoveSpeed = moveSpeed;
        cellController.GenerateCell();

        currentCellEnding = cellController.CellEnding;
    }

    private void CreateCell()
    {
        if (cellCount == 0)
        {
            newSection = true;
            cellCount = Random.Range(SECTION_LENGTH_MIN, SECTION_LENGTH_MAX);
        }

        if (currentCellEnding == null)
        {
            newSection = false;
            CreateCell(bGCell_Start, transform.position);
            indexSortingOrder = 0;
        }
        else if (newSection)
        {
            newSection = false;
            currentCellEnding.position = new Vector3(currentCellEnding.position.x - 0.1f, currentCellEnding.position.y, currentCellEnding.position.z);
            CreateCell(bGCell_Start, currentCellEnding.position);
        }
        else if (cellCount == 1)
        {
            currentCellEnding.position = new Vector3(currentCellEnding.position.x - 0.1f, currentCellEnding.position.y, currentCellEnding.position.z);
            CreateCell(bGCell_End, currentCellEnding.position);
        }
        else
        {
            currentCellEnding.position = new Vector3(currentCellEnding.position.x - 0.1f, currentCellEnding.position.y, currentCellEnding.position.z);
            CreateCell(bGCell_Body, currentCellEnding.position);
        }

        --cellCount;
        --indexSortingOrder;
    }
}