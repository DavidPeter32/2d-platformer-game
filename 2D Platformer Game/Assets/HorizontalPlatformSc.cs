using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatformSc : MonoBehaviour
{

    public Transform Point1 ,Point2;
    public float speed;
    public Transform startPoint;

    Vector3 nextPos;
    void Start()
    {
        nextPos = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove();
    }
    void HorizontalMove()
    {
        if (transform.position==Point1.position)
        {
            nextPos = Point2.position;
        }

        if (transform.position == Point2.position)
        {
            nextPos = Point1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(Point1.position, Point2.position);
    }

}
