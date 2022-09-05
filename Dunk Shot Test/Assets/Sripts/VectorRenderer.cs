using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Trajectory(Vector3 origin, Vector3 speed)
    {
        Vector3[] points = new Vector3[9];
        lineRenderer.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = origin + speed * time + Physics.gravity * time * time / 2f;
        }

        lineRenderer.SetPositions(points);
    }
}
