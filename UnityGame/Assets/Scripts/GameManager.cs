using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score = 0f;
    public bool spawnSwitch = false;
    public GameObject butterflyPrefab;
    public Transform[] spawnPoints;

    void Update()
    {
        GameObject[] butterflies = GameObject.FindGameObjectsWithTag("Butterfly");


        if (butterflies.Length <= 0)
        {
            SpawnButterfly(Random.Range(1, 4));
        }
        
        if (spawnSwitch == true)
        {
            SpawnButterfly(1);
            spawnSwitch = false;
        }
        
    }

    public void SpawnButterfly(int number)
    {
        for (int i = 0; i < number; i++)
        {
            int randomPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(butterflyPrefab, spawnPoints[randomPoint].position, Quaternion.identity);
        }
        Debug.Log($"Spawned: {number} \"{butterflyPrefab.name}\"");
    }

    public void AddToScore(int num)
    {
        score += num;
    }
}
