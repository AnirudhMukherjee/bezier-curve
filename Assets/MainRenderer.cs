using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRenderer : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public LineRenderer lineRenderer;
    public float vertexCount = 12;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pointList = new List<Vector3>();
        for(float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
        {
            var tLine1 = Vector3.Lerp(point1.position, point2.position,ratio);
            var tLine2 = Vector3.Lerp(point2.position, point3.position,ratio);
            var bezierP = Vector3.Lerp(tLine1, tLine2, ratio);
            pointList.Add(bezierP);
        }
        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(point1.position, point2.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(point2.position, point3.position);
        for (float ratio = 0.5f / vertexCount; ratio < 1; ratio += 1.0f / vertexCount)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.Lerp(point1.position, point2.position, ratio), Vector3.Lerp(point2.position, point3.position, ratio));
        }
    }
}
