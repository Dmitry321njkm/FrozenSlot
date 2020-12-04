using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsState
{
    private const string LEVEL_AVAILIBLE = "LevelAvailible";

    public static bool IsLevelAvailible(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + LEVEL_AVAILIBLE))
        {
            PlayerPrefs.SetInt(levelId + LEVEL_AVAILIBLE, 0);
        }
        return (PlayerPrefs.GetInt(levelId + LEVEL_AVAILIBLE) == 1);
    }

    public static void UnlockLevel(int levelId)
    {
        PlayerPrefs.SetInt(levelId + LEVEL_AVAILIBLE, 1);
    }
}
