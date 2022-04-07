using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    // Settings
    public static float butterfliesSpeed = 3;
    public static bool soundStatus = true;
    public static bool musicStatus = true;

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
}
