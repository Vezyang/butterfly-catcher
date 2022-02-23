using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool spawnSwitch = false;
    public GameObject butterflyPrefab;
    public Transform spawnPos;

    void Update()
    {
        if (spawnSwitch == true)
        {
            SpawnButterfly();
            spawnSwitch = false;
        }  
    }

    void SpawnButterfly()
    {
        Instantiate(butterflyPrefab, spawnPos.position, Quaternion.identity);
    }
}
