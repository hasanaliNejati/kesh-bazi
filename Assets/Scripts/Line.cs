using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Line : MonoBehaviour
{
    LineRenderer _lineRenderer;
    LineRenderer lineRenderer { get { return _lineRenderer?_lineRenderer:_lineRenderer = GetComponent<LineRenderer>(); } } 

    public void setPoint(Vector3[] points)
    {
        lineRenderer.positionCount=points.Length;
        lineRenderer.SetPositions(points);
    }
}
