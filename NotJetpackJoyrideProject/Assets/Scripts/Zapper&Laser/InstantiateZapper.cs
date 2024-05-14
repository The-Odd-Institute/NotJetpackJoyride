using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateZapper : MonoBehaviour
{
    private GameObject newZapper = null;
    public GameObject zapper;
    private GameObject endZapper;
   // private GameObject startZapper;
    //private GameObject centerPivot;
    private GameObject boxCollider;

    //[SerializeField] private bool rotatingZapper = false;

    //used for adjusting the length of zapper
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;

    //used for adjusting the rotation of zapper
    [SerializeField] private float minRot;
    [SerializeField] private float maxRot;

    float zapper_Length;
    float zapper_Rotation;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    InstantiateObject(1);
        //}
    }

    public void InstantiateObject(int offset)
    {



        //random distance

        //random rotation

        zapper_Length = Random.Range(minSize, maxSize);
        zapper_Rotation = Random.Range(minSize, maxSize);

        //instantiate
        newZapper = Instantiate(zapper, new Vector2(gameObject.transform.position.x, offset), Quaternion.Euler(0, 0, zapper_Rotation));
        newZapper.GetComponent<MoveLeft>().IsMoving = true;


        //get its children
        
        endZapper = newZapper.transform.GetChild(1).gameObject;
        boxCollider = newZapper.transform.GetChild(2).gameObject;

        //length of how far away the end of the zapper will be
        //needs formula for rotation, not following box collider nor center pivot
        endZapper.transform.position = new Vector2(zapper_Length, endZapper.transform.position.y);
        //endZapper.transform.position = new Vector2(endZapper.transform.position.x + zapper_Length * Mathf.Cos(zapper_Rotation), endZapper.transform.position.y + zapper_Length * Mathf.Sin(zapper_Rotation));

        //scales box collider depending on zapper length
        boxCollider.transform.localScale = new Vector3(zapper_Length, boxCollider.transform.localScale.y, boxCollider.transform.localScale.z);



        //if (rotatingZapper)
        //{
        //    //rotating script
        //    newZapper.GetComponent<Rotate>().IsRotating = true;

        //    //change laser color
        //    startZapper = newZapper.transform.GetChild(0).gameObject;
        //    centerPivot = newZapper.transform.GetChild(3).gameObject;
        //    centerPivot.transform.localScale = new Vector3(zapper_Length, centerPivot.transform.localScale.y, centerPivot.transform.localScale.z);
        //    startZapper.GetComponent<LineRenderer>().startColor = Color.red;
        //}

    }

}
