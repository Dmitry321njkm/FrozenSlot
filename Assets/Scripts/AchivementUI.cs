using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchivementUI : MonoBehaviour
{
    [SerializeField] private AchivementCell _openTheGame;
    [SerializeField] private AchivementCell _freeSpin;
    [SerializeField] private AchivementCell _scatter;
    [SerializeField] private AchivementCell _wild;
    [SerializeField] private AchivementCell _maxBet;
    [SerializeField] private AchivementCell _doSpecialEvents;
    [SerializeField] private AchivementCell _collectDiamond;
    [SerializeField] private AchivementCell _openAllLevel;
    [SerializeField] private AchivementCell _collectMoney;
    [SerializeField] private AchivementCell _getDailyBonus;
    [SerializeField] private AchivementCell _makeLines;
    [SerializeField] private AchivementCell _openAchivement;


    private void OnEnable()
    {
        CheckValueAchivement();
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
        AchivementCheck(_maxBet, Achivements.GetCompleteSpecialEventsProcent(), Achivements.MAX_BET_NUMBER);
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
        _cell.Percent.text = (_percent * 100).ToString() + "%";
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
