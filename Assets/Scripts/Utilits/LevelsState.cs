using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelsState
{
    private const string LEVEL_AVAILIBLE = "LevelAvailible";
    private const string FREE_SPIN = "FreeSpin";
    private const string BET = "Bet";
    private const string REST_OF_TIME = "RectOfTime";
    private const int DAYS_COUNT = 2;
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
        SetRectOfTime(levelId);
        Achivements.SetOpenTheLevelCounter();
    }

    public static void LockLevel(int levelId)
    {
        PlayerPrefs.SetInt(levelId + LEVEL_AVAILIBLE, 0);
    }

    public static System.TimeSpan GetRestOfTime(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + REST_OF_TIME))
        {
            SetRectOfTime(levelId);
        }
        return StringToDateTime(PlayerPrefs.GetString(levelId + REST_OF_TIME)) - System.DateTime.Now;
    }

    private static void SetRectOfTime(int levelId)
    {
        PlayerPrefs.SetString(levelId + REST_OF_TIME, DateTimeToString(System.DateTime.Now.AddDays(DAYS_COUNT)));
    }

    private static string DateTimeToString(System.DateTime dateTime)
    {
        return dateTime.Year + " " + dateTime.Month + " " + dateTime.Day + " " + dateTime.Hour + " " + dateTime.Month + " " + dateTime.Second;
    }

    private static System.DateTime StringToDateTime(string dateTimeString)
    {
        string[] str = dateTimeString.Split(' ');
        return new System.DateTime(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2]), int.Parse(str[3]), int.Parse(str[4]), int.Parse(str[5]));
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
