using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLineRenderer : MonoBehaviour
{
    public Transform laserFirePoint;
    public Transform laserEndPoint;
    public LineRenderer _lineRenderer;
    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        Draw2DRay(laserFirePoint.position, laserEndPoint.position);
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        _lineRenderer.SetPosition(0, startPos);
        _lineRenderer.SetPosition(1, endPos);
    }
}
