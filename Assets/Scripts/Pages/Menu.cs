using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Menu : Page
{
    [Serializable]
    public class LevelButton
    {
        [SerializeField]
        private int levelId = default;
        [SerializeField]
        private int priceCoin = default;
        [SerializeField]
        private int priceDiamond = default;
        [Space]
        [SerializeField]
        private Button button = default;
        [SerializeField]
        private Image unlockImage = default;
        [SerializeField]
        private Image lockImage = default;
        [SerializeField]
        private Text priceCoinText = default;
        [SerializeField]
        private Text priceDiamondText = default;

        public void Init()
        {
            button.onClick.AddListener(OpenOrBuy);
            priceCoinText.text = LevelsState.IsLevelAvailible(levelId - 1) ?
                (SetMoneyText(Purse.Coins) + "/" + SetMoneyText(priceCoin)) :
                (SetMoneyText(priceCoin) + "");
            priceDiamondText.text = LevelsState.IsLevelAvailible(levelId - 1) ?
                (SetMoneyText(Purse.Diamonds) + "/" + SetMoneyText(priceDiamond)) :
                (priceDiamond + "");
            if (LevelsState.IsLevelAvailible(levelId))
            {
                Unlock();
            }
            else
            {
                Lock();
            }
        }

        private void OpenOrBuy()
        {
            if (LevelsState.IsLevelAvailible(levelId))
            {
                OpenLevel();
            }
            else
            {
                if (Purse.RemoveMoney(priceCoin, priceDiamond))
                {
                    LevelsState.UnlockLevel(levelId);
                    Unlock();
                    OpenLevel();
                }
            }
        }

        private string SetMoneyText(int price)
        {
            string endPrice = "";
            for (; price > 1000; )
            {
                endPrice += "K";
                price /= 1000;
            }
            return price + endPrice;
        }

        private void OpenLevel()
        {
            MenuPage.Close();
            LevelPages[levelId].Open();
        }

        private void Lock()
        {
            unlockImage.enabled = false;
            lockImage.enabled = true;
            priceCoinText.gameObject.SetActive(priceCoin != 0);
            priceDiamondText.gameObject.SetActive(priceDiamond != 0);
        }

        private void Unlock()
        {
            unlockImage.enabled = true;
            lockImage.enabled = false;
            priceCoinText.gameObject.SetActive(false);
            priceDiamondText.gameObject.SetActive(false);
        }
    }

    [SerializeField]
    private LevelButton[] levelButtons = default;
    [SerializeField]
    private Button soundSettingsButton = default;
    [SerializeField]
    private Button newGameButton = default;

    private new void Awake()
    {
        base.Awake();
        MenuPage = this;

        if (!LevelsState.IsLevelAvailible(0))
        {
            LevelsState.UnlockLevel(0);
        }
        soundSettingsButton.onClick.AddListener(OpenSoundSettings);
        newGameButton.onClick.AddListener(NewGame);
    }

    private void OnDestroy()
    {
        soundSettingsButton.onClick.RemoveListener(OpenSoundSettings);

    }

    public override void Open()
    {
        base.Open();
        foreach (var levelButton in levelButtons)
        {
            levelButton.Init();
        }
    }

    private void NewGame()
    {
        Purse.RemoveAllMoney();
        for (int i = 0; i < LevelPages.Length; i++)
        {
            LevelsState.AddFreeSpin(i, 10);
            LevelsState.LockLevel(i);
        }
        LevelsState.UnlockLevel(0);
        Close();
        StartScreenPage.Open();
    }

    private void OpenSoundSettings()
    {
        SoundSettingsPage.Open();
    }
}
