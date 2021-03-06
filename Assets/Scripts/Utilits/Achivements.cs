﻿using UnityEngine;

public static class Achivements
{
    private const string OPEN_THE_GAME = "OpenTheGame";
    public const int OPEN_THE_GAME_NUMBER = 1000;
    private static int openTheGameCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(OPEN_THE_GAME))
            {
                openTheGameCounter = 0;
            }
            return PlayerPrefs.GetInt(OPEN_THE_GAME);
        }
        set
        {
            PlayerPrefs.SetInt(OPEN_THE_GAME, value);
        }
    }
    public static void SetOpenTheGameCounter()
    {
        openTheGameCounter++;
    }
    public static float GetOpenTheGameProcent()
    {
        return (float)openTheGameCounter / (float)OPEN_THE_GAME_NUMBER;
    }

    private const string FREE_SPIN = "FreeSpin";
    public const int FREE_SPIN_NUMBER = 5000;
    private static int freeSpinCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(FREE_SPIN))
            {
                freeSpinCounter = 0;
            }
            return PlayerPrefs.GetInt(FREE_SPIN);
        }
        set
        {
            PlayerPrefs.SetInt(FREE_SPIN, value);
        }
    }
    public static void SetFreeSpinCounter()
    {
        freeSpinCounter++;
    }
    public static float GetFreeSpinProcent()
    {
        return (float)freeSpinCounter / (float)FREE_SPIN_NUMBER;
    }

    private const string SCATTER = "Scatter";
    public const int SCATTER_NUMBER = 2000;
    private static int scatterCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(SCATTER))
            {
                scatterCounter = 0;
            }
            return PlayerPrefs.GetInt(SCATTER);
        }
        set
        {
            PlayerPrefs.SetInt(SCATTER, value);
        }
    }
    public static void SetScatterCounter()
    {
        scatterCounter++;
    }
    public static float GetScatterProcent()
    {
        return (float)scatterCounter / (float)SCATTER_NUMBER;
    }

    private const string WILD = "Wild";
    public const int WILD_NUMBER = 1000;
    private static int wildCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(WILD))
            {
                wildCounter = 0;
            }
            return PlayerPrefs.GetInt(WILD);
        }
        set
        {
            PlayerPrefs.SetInt(WILD, value);
        }
    }
    public static void SetWildCounter()
    {
        wildCounter++;
    }
    public static float GetWildProcent()
    {
        return (float)wildCounter / (float)WILD_NUMBER;
    }

    private const string MAX_BET = "MaxBet";
    public const int MAX_BET_NUMBER = 500;
    private static int maxBetCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(MAX_BET))
            {
                maxBetCounter = 0;
            }
            return PlayerPrefs.GetInt(MAX_BET);
        }
        set
        {
            PlayerPrefs.SetInt(MAX_BET, value);
        }
    }
    public static void SetMaxBetCounter()
    {
        maxBetCounter++;
    }
    public static float GetMaxBetProcent()
    {
        return (float)maxBetCounter / (float)MAX_BET_NUMBER;
    }

    // TODO;
    private const string COMPLETE_SPECIAL_EVENTS = "CompleteSpetialEvents";
    public const int COMPLETE_SPECIAL_EVENTS_NUMBER = 5;
    private static int completeSpecialEventsCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(COMPLETE_SPECIAL_EVENTS))
            {
                completeSpecialEventsCounter = 0;
            }
            return PlayerPrefs.GetInt(COMPLETE_SPECIAL_EVENTS);
        }
        set
        {
            PlayerPrefs.SetInt(COMPLETE_SPECIAL_EVENTS, value);
        }
    }
    public static void SetCompleteSpecialEventsCounter()
    {
        completeSpecialEventsCounter++;
    }
    public static float GetCompleteSpecialEventsProcent()
    {
        return (float)completeSpecialEventsCounter / (float)COMPLETE_SPECIAL_EVENTS_NUMBER;
    }

    private const string COLLECT_DIAMONDS = "CollectDiamonds";
    public const int COLLECT_DIAMONDS_NUMBER = 100000;
    private static int collectDiamondsCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(COLLECT_DIAMONDS))
            {
                collectDiamondsCounter = 0;
            }
            return PlayerPrefs.GetInt(COLLECT_DIAMONDS);
        }
        set
        {
            PlayerPrefs.SetInt(COLLECT_DIAMONDS, value);
        }
    }
    public static void SetCollectDiamondsCounter(int count)
    {
        collectDiamondsCounter += count;
    }
    public static float GetCollectDiamondsProcent()
    {
        return (float)collectDiamondsCounter / (float)COLLECT_DIAMONDS_NUMBER;
    }

    private const string OPEN_ALL_LEVELS = "OpenAllLevels";
    public const int OPEN_ALL_LEVELS_NUMBER = 6;
    private static int openTheLevelCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(OPEN_ALL_LEVELS))
            {
                openTheLevelCounter = 0;
            }
            return PlayerPrefs.GetInt(OPEN_ALL_LEVELS);
        }
        set
        {
            PlayerPrefs.SetInt(OPEN_ALL_LEVELS, value);
        }
    }
    public static void SetOpenTheLevelCounter()
    {
        openTheLevelCounter++;
    }
    public static float GetOpenTheLevelProcent()
    {
        if (((float)openTheLevelCounter / (float)OPEN_ALL_LEVELS_NUMBER) > 1)
        {
            return 1;
        }
        return (float)openTheLevelCounter / (float)OPEN_ALL_LEVELS_NUMBER;
    }

    private const string COLLECT_MONEY = "ColectMoney";
    public const int COLLECT_MONEY_NUMBER = 2000000;
    private static int collectMoneyCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(COLLECT_MONEY))
            {
                collectMoneyCounter = 0;
            }
            return PlayerPrefs.GetInt(COLLECT_MONEY);
        }
        set
        {
            PlayerPrefs.SetInt(COLLECT_MONEY, value);
        }
    }
    public static void SetCollectMoneyCounter(int count)
    {
        collectMoneyCounter += count;
    }
    public static float GetCollectMoneyProcent()
    {
        return (float)collectMoneyCounter / (float)COLLECT_MONEY_NUMBER;
    }

    private const string GET_DAILY_BONUS = "GetDailyBonus";
    public const int GET_DAILY_BONUS_NUMBER = 1000;
    private static int getDailyBonusCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(GET_DAILY_BONUS))
            {
                getDailyBonusCounter = 0;
            }
            return PlayerPrefs.GetInt(GET_DAILY_BONUS);
        }
        set
        {
            PlayerPrefs.SetInt(GET_DAILY_BONUS, value);
        }
    }
    public static void SetGetDailyBonusCounter()
    {
        getDailyBonusCounter++;
    }
    public static float GetGetDailyBonusCounterProcent()
    {
        return (float)getDailyBonusCounter / (float)GET_DAILY_BONUS_NUMBER;
    }

    private const string LINES = "Lines";
    public const int LINES_NUMBER = 500000;
    private static int linesCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(LINES))
            {
                linesCounter = 0;
            }
            return PlayerPrefs.GetInt(LINES);
        }
        set
        {
            PlayerPrefs.SetInt(LINES, value);
        }
    }
    public static void SetLinesCounter()
    {
        linesCounter++;
    }
    public static float GetLinesCounterProcent()
    {
        return (float)linesCounter / (float)LINES_NUMBER;
    }

    private const string OPEN_ACHIVEMENTS = "OpenAchivements";
    public const int OPEN_ACHIVEMENTS_NUMBER = 10000;
    private static int openAchivementsCounter
    {
        get
        {
            if (!PlayerPrefs.HasKey(OPEN_ACHIVEMENTS))
            {
                linesCounter = 0;
            }
            return PlayerPrefs.GetInt(OPEN_ACHIVEMENTS);
        }
        set
        {
            PlayerPrefs.SetInt(OPEN_ACHIVEMENTS, value);
        }
    }
    public static void SetOpenAchivementsCounter()
    {
        openAchivementsCounter++;
    }
    public static float GetOpenAchivementsCounterProcent()
    {
        return (float)openAchivementsCounter / (float)OPEN_ACHIVEMENTS_NUMBER;
    }
}
