using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game:")]
    public float score = 0f;
    [Header("Butterfly settings:")]
    public GameObject[] butterflyPrefabs = new GameObject[1];
    public float moveButterfliesX;
    public float moveButterfliesZ;
    [Header("Spawn settings:")]
    public Transform[] spawnPoints = new Transform[1];
    [Header("Pause game:")]
    public bool gameIsPaused = false;

    void Start()
    {
        Vector3 tLEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane));
        Vector3 rBEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, Camera.main.nearClipPlane));

        spawnPoints[0].position = new Vector3(tLEdge.x, 1, tLEdge.z);
        spawnPoints[1].position = new Vector3(rBEdge.x, 1, tLEdge.z);
        spawnPoints[2].position = new Vector3(tLEdge.x, 1, rBEdge.z);
        spawnPoints[3].position = new Vector3(rBEdge.x, 1, rBEdge.z);

        moveButterfliesX = tLEdge.x;
        moveButterfliesZ = rBEdge.z;

    }

    void Update()
    {
        GameObject[] butterflies = GameObject.FindGameObjectsWithTag("Butterfly");


        if (butterflies.Length <= 0)
        {
            SpawnButterfly(Random.Range(1, 4), butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
        }
    }

    public void SpawnButterfly(int number, GameObject butterfly)
    {
        int spawnNum = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < number; i++)
        {
            while (true)
            {
                int randomPoint = Random.Range(0, spawnPoints.Length);
                if (randomPoint != spawnNum)
                {
                    spawnNum = randomPoint;
                    Instantiate(butterfly, spawnPoints[randomPoint].position, Quaternion.identity);
                    break;
                }
            }
        }
        Debug.Log($"Spawned: {number} \"{butterfly.name}\"");
    }

    public void AddToScore(int num)
    {
        score += num;
    }
}
