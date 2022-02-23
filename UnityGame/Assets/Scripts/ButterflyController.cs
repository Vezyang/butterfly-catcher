using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Transform butterflyObject;
    public int minMove = -4;
    public int maxMove = 4;

    void Update()
    {
        RandomMove();
    }

    void RandomMove()
    {
        if (Vector3.Distance(butterflyObject.position, movePoint.position) < 0.2f)
        {
            movePoint.position = new Vector3(Random.Range(minMove, maxMove), movePoint.position.y, Random.Range(minMove, maxMove));
        }
        else
        {
            butterflyObject.position = Vector3.MoveTowards(butterflyObject.position, movePoint.position, moveSpeed * Time.deltaTime);
        }
    }
}
