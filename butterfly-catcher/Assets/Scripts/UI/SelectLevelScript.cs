using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelScript : MonoBehaviour
{
    public GameObject[] levelList;

    private void Awake()
    {
        for (int i = levelList.Length - 1; i > Data.Level - 1; i--)
        {
            levelList[i].SetActive(false);
        }
    }
}
