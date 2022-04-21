using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Game:")]
    public GameMode gameMode;
    public float score = 0f;
    public Text scoreText;
    
    [Header("Butterfly settings:")]
    public AudioSource audioSource;
    public AudioClip catchEffect;
    public GameObject[] butterflyPrefabs;
    public float moveButterfliesX;
    public float moveButterfliesZ;
    
    [Header("Spawn settings:")]
    public Transform[] spawnPoints;

    private float spawnRate = 3f;
    private float nextSpawn;

    void Start()
    {
        Time.timeScale = 0f;
        Vector3 tLEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f, Camera.main.nearClipPlane));
        Vector3 rBEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, Camera.main.nearClipPlane));

        spawnPoints[0].position = new Vector3(tLEdge.x - 0.5f, 1, tLEdge.z + 0.5f);
        spawnPoints[1].position = new Vector3(rBEdge.x + 0.5f, 1, tLEdge.z + 0.5f);
        spawnPoints[2].position = new Vector3(tLEdge.x - 0.5f, 1, rBEdge.z - 0.5f);
        spawnPoints[3].position = new Vector3(rBEdge.x + 0.5f, 1, rBEdge.z - 0.5f);

        moveButterfliesX = tLEdge.x;
        moveButterfliesZ = rBEdge.z;

        bool check = false;
        for (int i = 0; i < butterflyPrefabs.Length; i++)
        {
            check = false;
            foreach (var item in Data.butterfliesCaught)
            {
                if (butterflyPrefabs[i].name == item.name)
                {
                    check = true;
                    Debug.Log("true");
                }
            }
            if (check == false)
            {
                Data.butterfliesCaught.Add(new Data.Butterflies());
                Data.butterfliesCaught[Data.butterfliesCaught.Count - 1].AddButterfly(butterflyPrefabs[i].name, 0);
                Debug.Log("false");
            }
        }
    }

    void Update()
    {
        GameObject[] butterflies = GameObject.FindGameObjectsWithTag("Butterfly");
        if (butterflies.Length < 4f)
        {
            SpawnButterfly(Random.Range(1, 5), butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
        }
        else if(Time.time > nextSpawn && butterflies.Length <= 5f)
        {
            RandomSpawnButterfly(3);
        }
    }

    public void SpawnButterfly(int number, GameObject butterfly)
    {
        int[] rs = new int[spawnPoints.Length];

        for (int i = 0; i < rs.Length; i++)
        {
            rs[i] = i;
        }
        
        for (int i = rs.Length - 1; i >= 0; i--)
        {
            int tmp = rs[i];
            int rand = Random.Range(0, i + 1);
            rs[i] = rs[rand];
            rs[rand] = tmp;
        }
        
        for (int i = 0; i < number; i++)
        {
            GameObject obj = Instantiate(butterfly, spawnPoints[rs[i]].position, Quaternion.identity);
            obj.name = butterfly.name.Replace("(Clone)", "");
        }
        Debug.Log($"Spawned: {number} \"{butterfly.name}\"");
    }

    private void RandomSpawnButterfly(int max)
    {
        spawnRate = Random.Range(3, 5);
        nextSpawn = Time.time + spawnRate;
        SpawnButterfly(Random.Range(1, max), butterflyPrefabs[Random.Range(0, butterflyPrefabs.Length)]);
    }

    public void CheckButterfly()
    {
        audioSource.PlayOneShot(catchEffect);
        gameMode.Catching();
    }
}
