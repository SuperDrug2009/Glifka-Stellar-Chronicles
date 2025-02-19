using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ArrowMovement : MonoBehaviour
{
    [SerializeField] public PowerMeter powerMeter;
    public Transform p0;
    public Transform p1;
    public Transform p2;
    public Transform p3;

    [Range(0, 1)]
    public float t;

    private void Update()
    {
        t = powerMeter.t;

        transform.position = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t);

    }

    private void OnDrawGizmos()
    {
        int number = 20;
        Vector3 preveousPoint = p0.position;

        for (int i = 0; i < number + 1; i++)
        {
            float parameter = (float)i / number;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(preveousPoint, point);
            preveousPoint = point;
        }
    }
}
