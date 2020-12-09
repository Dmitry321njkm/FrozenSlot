using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsState
{
    private const string LEVEL_AVAILIBLE = "LevelAvailible";
    private const string FREE_SPIN = "FreeSpin";
    private const string BET = "Bet";
    public const int MAX_FREE_SPIN = 10;

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

    public static int GetFreeSpin(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + FREE_SPIN))
        {
            PlayerPrefs.SetInt(levelId + FREE_SPIN, 10);
        }
        return PlayerPrefs.GetInt(levelId + FREE_SPIN);
    }

    public static void AddFreeSpin(int levelId, int value)
    {
        PlayerPrefs.SetInt(levelId + FREE_SPIN, GetFreeSpin(levelId) + value);
        if (GetFreeSpin(levelId) > MAX_FREE_SPIN)
        {
            PlayerPrefs.SetInt(levelId + FREE_SPIN, MAX_FREE_SPIN);
        }
    }

    public static void RemoveFreeSpin(int levelId)
    {
        PlayerPrefs.SetInt(levelId + FREE_SPIN, GetFreeSpin(levelId) - 1);
    }

    public static int Bet
    {
        get
        {
            if (!PlayerPrefs.HasKey(BET))
            {
                Bet = 0;
            }
            return PlayerPrefs.GetInt(BET);
        }
        set
        {
            PlayerPrefs.SetInt(BET, value);
        }
    }
}
