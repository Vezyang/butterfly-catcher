using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMode : MonoBehaviour
{
    [System.Serializable]
    public class Mission
    {
        public GameObject target;
        public int start;
        public int amount;
    }

    public enum Mode
    {
        chaching,
        time
    }

    public Mission[] missions;
    public Text[] ex;
    public UIManager uIManager;
    int[] index;

    void Start()
    {
        index = new int[missions.Length];
        int num = 0;
        for (int i = 0; i < missions.Length; i++)
        {
            for (int j = 0; j < Data.butterfliesCaught.Count; j++)
            {
                if (Data.butterfliesCaught[j].name == missions[i].target.name)
                {
                    missions[i].start = Data.butterfliesCaught[j].caught;
                    index[num] = j;
                    num++;
                }
            }
        }
    }
    public void Catching()
    {
        int j = 0;
        for (int i = 0; i < missions.Length; i++)
        {
            ex[i].text = missions[i].start + missions[i].amount < Data.butterfliesCaught[index[i]].caught
                ? $"x{missions[i].amount}+"
                : $"x{Data.butterfliesCaught[index[i]].caught - missions[i].start}";
            if (Data.butterfliesCaught[index[i]].caught - missions[i].start >= missions[i].amount)
            {
                j++;
            }
        }
        if (j == missions.Length)
        {
            int lvl = System.Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("Level_", "")) + 1;
            if (Data.Level < lvl)
            {
                Data.Level = lvl;
            }
            uIManager.CloseAllPanels();
            uIManager.OpenElementWithPause("completed");
        }
    }
}
