using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateZapper : MonoBehaviour
{
    public GameObject zapper;
    private GameObject endZapper;
    private GameObject boxCollider;

    //used for adjusting the length of zapper
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    //used for adjusting the rotation of zapper
    [SerializeField] private float minRot;
    [SerializeField] private float maxRot;

    float zapper_Length;

    int spawnOffset = -4;

    // Start is called before the first frame update
    void Start()
    {
        endZapper = zapper.transform.GetChild(1).gameObject;
        boxCollider = zapper.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            InstantiateObject(spawnOffset);
            //spawn offset is just for testing
            spawnOffset += 1;
        }
    }

    public void InstantiateObject(int offset)
    {

        //random distance

        //random rotation

        zapper_Length = Random.Range(minSize, maxSize);

        //instantiate
        GameObject newZapper = Instantiate(zapper, new Vector2(gameObject.transform.position.x, offset), Quaternion.Euler(0, 0, Random.Range(minRot, maxRot)));
        newZapper.GetComponent<MoveLeft>().IsMoving = true;

        //length of how far away the end of the zapper will be
        endZapper.transform.position = new Vector2(zapper_Length, endZapper.transform.position.y);

        //scales box collider depending on zapper length
        boxCollider.transform.localScale = new Vector3(zapper_Length, boxCollider.transform.localScale.y, boxCollider.transform.localScale.z);

    }

}
