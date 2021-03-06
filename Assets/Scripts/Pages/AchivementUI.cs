﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementUI : Page
{
    [SerializeField] private AchivementCell _openTheGame = default;
    [SerializeField] private AchivementCell _freeSpin = default;
    [SerializeField] private AchivementCell _scatter = default;
    [SerializeField] private AchivementCell _wild = default;
    [SerializeField] private AchivementCell _maxBet = default;
    [SerializeField] private AchivementCell _doSpecialEvents = default;
    [SerializeField] private AchivementCell _collectDiamond = default;
    [SerializeField] private AchivementCell _openAllLevel = default;
    [SerializeField] private AchivementCell _collectMoney = default;
    [SerializeField] private AchivementCell _getDailyBonus = default;
    [SerializeField] private AchivementCell _makeLines = default;
    [SerializeField] private AchivementCell _openAchivement = default;

    [SerializeField]
    private Button backButton = default;

    private new void Awake()
    {
        base.Awake();
        backButton.onClick.AddListener(Back);
    }

    private void OnDestroy()
    {
        backButton.onClick.RemoveListener(Back);
    }

    public override void Open()
    {
        base.Open();
        CheckValueAchivement();
        Achivements.SetOpenAchivementsCounter();
    }

    private void Back()
    {
        Close();
    }

    void CheckValueAchivement()
    {
        OpenTheGameCheck();
        FreeSpeenCheck();
        ScatterCheck();
        WildCheck();
        MaxBetCheck();
        DoSpecialEventsCheck();
        CollectDiamondCheck();
        OpenAllLevelCheck();
        CollectMoneyCheck();
        GetDailyBonusCheck();
        MakeItemsCheck();
        OpenAchivementsCheck();
    }

    void OpenTheGameCheck()
    { 
        AchivementCheck(_openTheGame, Achivements.GetOpenTheGameProcent(), Achivements.OPEN_THE_GAME_NUMBER);
    }

    void FreeSpeenCheck()
    {
        AchivementCheck(_freeSpin, Achivements.GetFreeSpinProcent(), Achivements.FREE_SPIN_NUMBER);
    }

    void ScatterCheck()
    {
        AchivementCheck(_scatter, Achivements.GetScatterProcent(), Achivements.SCATTER_NUMBER);
    }

    void WildCheck()
    {
        AchivementCheck(_wild, Achivements.GetWildProcent(), Achivements.WILD_NUMBER);
    }

    void MaxBetCheck()
    {
        AchivementCheck(_maxBet, Achivements.GetMaxBetProcent(), Achivements.MAX_BET_NUMBER);
    }

    void DoSpecialEventsCheck()
    {
        AchivementCheck(_doSpecialEvents, Achivements.GetCompleteSpecialEventsProcent(), Achivements.COMPLETE_SPECIAL_EVENTS_NUMBER);
    }

    void CollectDiamondCheck()
    {
        AchivementCheck(_collectDiamond, Achivements.GetCollectDiamondsProcent(), Achivements.COLLECT_DIAMONDS_NUMBER);
    }

    void OpenAllLevelCheck()
    {
        AchivementCheck(_openAllLevel, Achivements.GetOpenTheLevelProcent(), Achivements.OPEN_ALL_LEVELS_NUMBER);
    }

    void CollectMoneyCheck()
    {
        AchivementCheck(_collectMoney, Achivements.GetCollectMoneyProcent(), Achivements.COLLECT_MONEY_NUMBER);
    }

    void GetDailyBonusCheck()
    {
        AchivementCheck(_getDailyBonus, Achivements.GetGetDailyBonusCounterProcent(), Achivements.GET_DAILY_BONUS_NUMBER);
    }

    void MakeItemsCheck()
    {
        AchivementCheck(_makeLines, Achivements.GetLinesCounterProcent(), Achivements.LINES_NUMBER);
    }

    void OpenAchivementsCheck()
    {
        AchivementCheck(_openAchivement, Achivements.GetOpenAchivementsCounterProcent(), Achivements.OPEN_ACHIVEMENTS_NUMBER);
    }

    void AchivementCheck(AchivementCell _cell, float _percent, int _number)
    {
        _cell.Percent.text = Mathf.Round(_percent * 100) + "%";
        _cell.ImageProgress.fillAmount = _percent;
        _cell.Number.text = "x" + _number;
    }

   
}


[System.Serializable]
public class AchivementCell
{
    public Image ImageProgress;
    public Text Percent;
    public Text Number;
}
