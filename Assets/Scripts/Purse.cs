using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Purse
{
    private const string COINS = "Coins";
    private const string DIAMONDS = "Diamonds";

    public static int Coins
    {
        get
        {
            if (PlayerPrefs.HasKey(COINS))
            {
                Coins = 0;
            }
            return PlayerPrefs.GetInt(COINS);
        }
        set
        {
            PlayerPrefs.SetInt(COINS, value);
        }
    }

    public static int Diamonds
    {
        get
        {
            if (PlayerPrefs.HasKey(DIAMONDS))
            {
                Diamonds = 0;
            }
            return PlayerPrefs.GetInt(DIAMONDS);
        }
        set
        {
            PlayerPrefs.SetInt(DIAMONDS, value);
        }
    }

    public static bool TryBuy(int coins, int diamonds)
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
