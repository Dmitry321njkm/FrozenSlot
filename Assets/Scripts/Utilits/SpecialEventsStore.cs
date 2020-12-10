using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpecialEventsStore
{
    private const string COLLECTED_COINS = "CollectedCoins";
    private const string COLLECTED_DIAMONDS = "CollectedDiamonds";
    private const string DID_TEN_FREE_SPINS = "DidTenFreeSpins";
    private const string DAILY_BONUS_GET = "DailyBonusGet";


    public static int GetCollectedCoins(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + COLLECTED_COINS))
        {
            PlayerPrefs.SetInt(levelId + COLLECTED_COINS, 0);
        }
        return PlayerPrefs.GetInt(levelId + COLLECTED_COINS);
    }

    public static void SetCollectedCoins(int levelId, int coins)
    {
        PlayerPrefs.SetInt(levelId + COLLECTED_COINS, GetCollectedCoins(levelId) + coins);
    }


    public static int GetCollectedDiamonds(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + COLLECTED_DIAMONDS))
        {
            PlayerPrefs.SetInt(levelId + COLLECTED_DIAMONDS, 0);
        }
        return PlayerPrefs.GetInt(levelId + COLLECTED_DIAMONDS);
    }

    public static void SetCollectedDiamonds(int levelId, int diamonds)
    {
        PlayerPrefs.SetInt(levelId + COLLECTED_DIAMONDS, GetCollectedDiamonds(levelId) + diamonds);
    }


    public static int GetDidTenFreeSpins(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + DID_TEN_FREE_SPINS))
        {
            PlayerPrefs.SetInt(levelId + DID_TEN_FREE_SPINS, 0);
        }
        return PlayerPrefs.GetInt(levelId + DID_TEN_FREE_SPINS);
    }

    public static void SetDidTenFreeSpins(int levelId)
    {
        PlayerPrefs.SetInt(levelId + DID_TEN_FREE_SPINS, GetDidTenFreeSpins(levelId) + 1);
    }


    public static bool NextLevelIsOpen(int levelId)
    {
        return LevelsState.IsLevelAvailible(levelId + 1);
    }


    public static bool IsDailyBonusGet(int levelId)
    {
        if (!PlayerPrefs.HasKey(levelId + DAILY_BONUS_GET))
        {
            PlayerPrefs.SetInt(levelId + DAILY_BONUS_GET, 0);
        }
        return PlayerPrefs.GetInt(levelId + DAILY_BONUS_GET) > 0;
    }

    public static void SetDailyBonusIsGet(int levelId)
    {
        PlayerPrefs.SetInt(levelId + DAILY_BONUS_GET, 1);
    }
}
