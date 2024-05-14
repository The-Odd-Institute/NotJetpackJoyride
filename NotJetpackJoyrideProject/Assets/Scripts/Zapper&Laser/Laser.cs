using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
   
    private GameObject rightLaser;
    private GameObject leftLaser;
    private GameObject boxCollider;
    //private GameObject newLaser = null;

    private LineRenderer lineRenderer;

    private float leftLaserStartPositionX;
    private float leftLaserEndPositionX;

    private float rightLaserStartPositionX;
    private float rightLaserEndPositionX;

    [SerializeField] private float laserMovementVariance;


    [SerializeField] private float laserWindup;
    [SerializeField] private float laserEase;
    //[SerializeField] private float laserPositionY;

    [SerializeField] private float laserWindupWidth;
    [SerializeField] private float laserActiveWidth;

    private float elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / laserEase;
        leftLaser.transform.position = Vector2.Lerp(new Vector2(leftLaserStartPositionX, leftLaser.transform.position.y), new Vector2(leftLaserEndPositionX, leftLaser.transform.position.y), Mathf.SmoothStep(0, 1, percentageComplete));
        rightLaser.transform.position = Vector2.Lerp(new Vector2(rightLaserStartPositionX, rightLaser.transform.position.y), new Vector2(rightLaserEndPositionX, rightLaser.transform.position.y), Mathf.SmoothStep(0, 1, percentageComplete));

    }

    private void Awake()
    {
        elapsedTime = 0;

        leftLaser = this.transform.GetChild(0).gameObject;
        lineRenderer = leftLaser.transform.GetComponent<LineRenderer>();
        rightLaser = this.transform.GetChild(1).gameObject;
        boxCollider = this.transform.GetChild(2).gameObject;

        leftLaserStartPositionX = leftLaser.transform.position.x;
        rightLaserStartPositionX = rightLaser.transform.position.x;

        leftLaserEndPositionX = leftLaserStartPositionX + laserMovementVariance;
        rightLaserEndPositionX = rightLaserStartPositionX - laserMovementVariance;

        Invoke("LaserWindupActivation", laserWindup / 1.5f);
    }

    private void LaserWindupActivation()
    {
        lineRenderer.enabled = true;
        lineRenderer.startWidth = laserWindupWidth;
        Invoke("LaserActivation", laserWindup);
    }

    private void LaserActivation()
    {
        //laser changes
        lineRenderer.startWidth = laserActiveWidth;
        boxCollider.SetActive(true);
        Invoke("LaserDeActivation", laserWindup);
    }

    private void LaserDeActivation()
    {
        //laser changes
        lineRenderer.enabled = false;
        boxCollider.SetActive(false);
        elapsedTime = 0;
        leftLaserStartPositionX = leftLaser.transform.position.x;
        rightLaserStartPositionX = rightLaser.transform.position.x;
        leftLaserEndPositionX = -11;
        rightLaserEndPositionX = 11;
        Destroy(gameObject, 2);
    }
}
