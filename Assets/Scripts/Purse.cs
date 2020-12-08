using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Purse
{
    private const string COINS = "Coins";
    private const string DIAMONDS = "Diamonds";
    private const int DEFAULT_COINS = 750;
    private const int DEFAULT_DIAMONDS = 0;

    public static int Coins
    {
        get
        {
            if (!PlayerPrefs.HasKey(COINS))
            {
                Coins = DEFAULT_COINS;
            }
            return PlayerPrefs.GetInt(COINS);
        }
        private set
        {
            PlayerPrefs.SetInt(COINS, value);
        }
    }

    public static int Diamonds
    {
        get
        {
            if (!PlayerPrefs.HasKey(DIAMONDS))
            {
                Diamonds = DEFAULT_DIAMONDS;
            }
            return PlayerPrefs.GetInt(DIAMONDS);
        }
        private set
        {
            PlayerPrefs.SetInt(DIAMONDS, value);
        }
    }

    public static bool AddMoney(int coins, int diamonds)
    {
        if ((Coins < -coins) && (Diamonds < -diamonds))
        {
            return false;
        }
        Coins += coins;
        Diamonds += diamonds;
        return true;
    }

    public static bool RemoveMoney(int coins, int diamonds)
    {
        if ((Coins < coins) || (Diamonds < diamonds))
        {
            return false;
        }
        Coins -= coins;
        Diamonds -= diamonds;
        return true;
    }
}
