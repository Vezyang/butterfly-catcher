using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Butterfly settings:")]
    [Range(1, 10)] public float moveSpeed = 3f;
    
    [Header("Move settings:")]
    public int minMove = -4;
    public int maxMove = 4;
    private Vector3 movePoint = new Vector3(0, 1, 0);

    private void Start()
    {
        try
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        catch
        {
            Debug.LogError("GameManager not found!");
        }

        NewMovePoint();
    }

    void Update()
    {
        RandomMove();
    }

    public void CatchButterfly()
    {
        Debug.Log($"Caught: {gameObject.name}");
        gameManager.AddToScore(1);
        Destroy(gameObject);
    }

    void RandomMove()
    {
        if (Vector3.Distance(transform.position, movePoint) < 0.2f)
        {
            NewMovePoint();
        }
        else
        {
            Vector3 direction = movePoint - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, moveSpeed * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, movePoint, moveSpeed * Time.deltaTime);
        }
    }

    void NewMovePoint()
    {
        movePoint = new Vector3(Random.Range(minMove, maxMove), movePoint.y, Random.Range(minMove, maxMove));
    }
}
