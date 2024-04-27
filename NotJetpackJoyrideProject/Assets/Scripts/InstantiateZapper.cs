using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateZapper : MonoBehaviour
{
    public GameObject zapper;
    private GameObject End_zapper;

    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    int spawnOffset = -4;

    // Start is called before the first frame update
    void Start()
    {
       End_zapper = zapper.transform.GetChild(1).gameObject;
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


        //instantiate
        Instantiate(zapper, new Vector3(0, offset, 0), Quaternion.identity);

        End_zapper.transform.position = new Vector3(Random.Range(minSize, maxSize), End_zapper.transform.position.y, End_zapper.transform.position.z);


    }

}
