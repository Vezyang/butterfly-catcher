using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game:")]
    public float score = 0f;
    public bool gameIsPaused = false;
    [Header("Butterfly settings:")]
    public GameObject[] butterflyPrefabs = new GameObject[1];
    public float moveButterfliesX;
    public float moveButterfliesZ;
    [Header("Spawn settings:")]
    public Transform[] spawnPoints = new Transform[1];

    private float spawnRate = 3f;
    private float nextSpawn;

    void Start()
    {
        Vector3 tLEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane));
        Vector3 rBEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, Camera.main.nearClipPlane));

        spawnPoints[0].position = new Vector3(tLEdge.x - 0.5f, 1, tLEdge.z + 0.5f);
        spawnPoints[1].position = new Vector3(rBEdge.x + 0.5f, 1, tLEdge.z + 0.5f);
        spawnPoints[2].position = new Vector3(tLEdge.x - 0.5f, 1, rBEdge.z - 0.5f);
        spawnPoints[3].position = new Vector3(rBEdge.x + 0.5f, 1, rBEdge.z - 0.5f);

        moveButterfliesX = tLEdge.x;
        moveButterfliesZ = rBEdge.z;

    }

    void Update()
    {
        GameObject[] butterflies = GameObject.FindGameObjectsWithTag("Butterfly");
        if (butterflies.Length <= 2f)
        {
            SpawnButterfly(Random.Range(1, 4), butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
        }
        else if(Time.time > nextSpawn && butterflies.Length < 5f)
        {
            RandomSpawnButterfly(3);
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

    private void RandomSpawnButterfly(int max)
    {
        spawnRate = Random.Range(3, 5);
        nextSpawn = Time.time + spawnRate;
        SpawnButterfly(Random.Range(1, max), butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
    }

    public void AddToScore(int num)
    {
        score += num;
    }
}
