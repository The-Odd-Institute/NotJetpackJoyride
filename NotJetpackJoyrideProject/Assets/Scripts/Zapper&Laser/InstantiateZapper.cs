using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateZapper : MonoBehaviour
{
    private GameObject newZapper = null;
    public GameObject zapper;
    private GameObject endZapper;
    private GameObject startZapper;
    private GameObject centerPivot;
    private GameObject boxCollider;

    [SerializeField] private bool rotatingZapper = false;

    //used for adjusting the length of zapper
    [SerializeField] private float minSize;
    [SerializeField] private float maxSize;
    //DO NOT SET MIN SIZE TO 0, It will break the box collider

    //used for adjusting the rotation of zapper
    [SerializeField] private float minRot;
    [SerializeField] private float maxRot;

    private Color orange = new Color(1.0f, 0.64f, 0.0f);

    float zapper_Length;
    float zapper_Rotation;


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
        zapper_Rotation = Random.Range(minRot, maxRot);


        //instantiate
        newZapper = Instantiate(zapper, new Vector2(gameObject.transform.position.x, offset), Quaternion.identity);

        //get its children
        endZapper = newZapper.transform.GetChild(1).gameObject;
        boxCollider = newZapper.transform.GetChild(2).gameObject;

        endZapper.transform.localPosition = new Vector2(zapper_Length, boxCollider.transform.localPosition.y);

        
        if (rotatingZapper)
        {
            //rotating script
            newZapper.GetComponent<Rotate>().IsRotating = true;

            //change laser color
            startZapper = newZapper.transform.GetChild(0).gameObject;
            centerPivot = newZapper.transform.GetChild(3).gameObject;
            centerPivot.transform.localPosition = new Vector2(zapper_Length/2, centerPivot.transform.localPosition.y);

            startZapper.GetComponent<LineRenderer>().startColor = orange;
            startZapper.GetComponent<LineRenderer>().endColor = orange;
        }



        newZapper.GetComponent<MoveLeft>().IsMoving = true;

       
        //scales box collider depending on zapper length
        boxCollider.transform.localScale = new Vector3(zapper_Length, boxCollider.transform.localScale.y, boxCollider.transform.localScale.z);

        //rotate the zapper last
        newZapper.transform.Rotate(0, 0, zapper_Rotation);

    }

}
