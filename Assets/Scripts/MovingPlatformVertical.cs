using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{
    [SerializeField]
    private GameObject pointA;
    [SerializeField]
    private GameObject pointB;
    private Transform currentPoint;

    private int verticalInput=1;
    [SerializeField]
    private int speed;

    private void Start()
    {
        currentPoint = pointB.transform;
    }

    private void Update()
    {
        if(currentPoint == pointB.transform)
        {
            verticalInput = -1;
        }
        else if(currentPoint == pointA.transform)
        {
            verticalInput = 1;
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform) {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
        Vector2 position = transform.position;
        position.y += verticalInput * speed * Time.deltaTime;
        transform.position = position;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
