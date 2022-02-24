using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool spawnSwitch = false;
    public GameObject butterflyPrefab;
    public Transform[] spawnPoints;

    void Update()
    {
        GameObject[] butterflies = GameObject.FindGameObjectsWithTag("Butterfly");


        if (butterflies.Length <= 0)
        {
            SpawnButterfly();
        }
        
        if (spawnSwitch == true)
        {
            SpawnButterfly();
            spawnSwitch = false;
        }
        
    }

    public void SpawnButterfly()
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(butterflyPrefab, spawnPoints[randomPoint].position, Quaternion.identity);
    }
}
