using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Butterfly settings:")]
    [Range(1, 10)] public float moveSpeed = 3f;
    [Range(1, 10)] public float rotationalSpeed = 1.5f;

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
        NewMovePoint(gameManager.moveButterfliesX, gameManager.moveButterfliesZ);
    }

    private void FixedUpdate()
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
        if (Vector3.Distance(transform.position, movePoint) < 1f)
        {
            NewMovePoint(gameManager.moveButterfliesX, gameManager.moveButterfliesZ);
        }
        else
        {
            Vector3 direction = movePoint - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalSpeed * Time.deltaTime);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
    
    void NewMovePoint(float moveX, float moveZ)
    {
        movePoint = new Vector3(Random.Range(moveX, -moveX), 1, Random.Range(moveZ, -moveZ));
    }
}
