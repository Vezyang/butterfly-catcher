using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticsScript : MonoBehaviour
{
    public GameObject[] allButterflies;
    public Text totalText;

    private void Awake()
    {
        // BUTTERFLIES
        for (int i = 0; i < allButterflies.Length; i++)
        {
            foreach (var item in Data.butterfliesCaught)
            {
                if (allButterflies[i].name == item.name)
                {
                    allButterflies[i].SetActive(true);
                    allButterflies[i].transform.GetChild(1).GetComponent<Text>().text = $"x{item.caught}";
                }
            }
        }

        // TOTAL
        int total = 0;
        for (int i = 0; i < Data.butterfliesCaught.Count; i++)
        {
            total += Data.butterfliesCaught[i].caught;
        }
        totalText.text = $"x{total}";
    }
}
