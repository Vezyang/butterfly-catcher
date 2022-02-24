using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    [Range(1, 10)]
    [Header("Butterfly settings:")]
    public float moveSpeed = 3f;
    public Transform butterflyObject;
    [Header("Move Settings:")]
    public Transform movePoint;
    public int minMove = -4;
    public int maxMove = 4;

    void Update()
    {
        RandomMove();
    }

    public void CatchButterfly()
    {
        Debug.Log($"Caught: {gameObject.name}");
        Destroy(gameObject);
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
