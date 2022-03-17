using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Butterfly settings:")]
    [Range(1, 10)] public float moveSpeed = 3f;
    
    private Vector3 movePoint;

    private void Start()
    {
        try
        {
            gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
        catch
        {
            Debug.LogError("GameManager not found.");
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
        Vector3 nowMovePoint = movePoint;

        movePoint = new Vector3(Mathf.Abs(Random.Range(gameManager.moveButterfliesX, -gameManager.moveButterfliesX)), 1, Random.Range(gameManager.moveButterfliesZ, -gameManager.moveButterfliesZ));
    }
}
