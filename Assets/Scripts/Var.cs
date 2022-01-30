using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Var
{
    public static int maxUnlockedLevel = 0;
    public static int currentLevel = 0;
    public static readonly int levelCount = 12;

    public static void Save()
    {
        PlayerPrefs.SetInt("maxLevel", maxUnlockedLevel);
        PlayerPrefs.SetInt("currentLevel", currentLevel);
    }


    public static void Load()
    {
        maxUnlockedLevel =PlayerPrefs.GetInt("maxLevel");
        currentLevel = PlayerPrefs.GetInt("currentLevel");
    }


}
