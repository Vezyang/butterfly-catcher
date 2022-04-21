using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    // Settings
    public static float butterfliesSpeed = 3;
    public static bool soundStatus = true;
    public static bool musicStatus = true;
    public static float musicVolume = 1;
    public static float effectsVolume = 1;

    // Statistics
    public class Butterflies
    {
        public string name;
        public int caught;

        public void AddButterfly(string name, int qantity)
        {
            this.name = name;
            caught = qantity;
        }
    }

    public static List<Butterflies> butterfliesCaught = new List<Butterflies>();
    public static int Level = 1;
}
