using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyController : MonoBehaviour
{
    private GameManager gameManager;

    [Header("Butterfly settings:")]
    [Range(1, 10)] public float moveSpeed;
    [Range(1, 10)] public float rotationalSpeed;

    private Vector3 movePoint;

    private void Start()
    {
        moveSpeed = Data.butterfliesSpeed;
        rotationalSpeed = Data.butterfliesSpeed / 2;
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
        Debug.Log($"Caught: \"{gameObject.name}\"");
        gameManager.AddToScore(1);
        //for (int i = 0; i < Data.butterfliesCaught.Count; i++)
        //{
        //    if (Data.butterfliesCaught[i].name == gameObject.name)
        //    {
        //        Data.butterfliesCaught[i].caught++;
        //    }
        //}
        bool check = false;
        foreach (var item in Data.butterfliesCaught)
        {
            if (item.name == gameObject.name)
            {
                item.caught++;
                check = true;
            }
        }
        if (check == false || Data.butterfliesCaught.Count == 0)
        {
            Data.butterfliesCaught.Add(new Data.Butterflies());
            Data.butterfliesCaught[Data.butterfliesCaught.Count - 1].AddButterfly(gameObject.name, 1);
        }
        Destroy(gameObject);
    }

    void RandomMove()
    {
        if (Vector3.Distance(transform.position, movePoint) < 2f)
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
