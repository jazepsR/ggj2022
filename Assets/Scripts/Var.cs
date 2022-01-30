using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Var
{
    public static int maxUnlockedLevel = 0;
    public static int currentLevel = 0;
    public static readonly int levelCount = 12;
    public static bool tutorialShown = false;

    public static void Save()
    {
        PlayerPrefs.SetInt("maxLevel", maxUnlockedLevel);
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        PlayerPrefs.SetInt("tutorialShown", boolToInt(tutorialShown));
    }


    public static void Load()
    {
        maxUnlockedLevel = PlayerPrefs.GetInt("maxLevel");
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        tutorialShown = intToBool(PlayerPrefs.GetInt("tutorialShown", 0));
    }


    public static int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    public static bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }
}
